using System.Linq.Expressions;
using Infrastructure.EfCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Infrastructure.EfCore;

public class MusclesRequestHandler : IRequestHandler<CreateMuscleRequest, Guid>,
    IRequestHandler<UpdateMuscleRequest>, IRequestHandler<DeleteGroupRequest>,
    IRequestHandler<GetMuscleByIdRequest, IMuscleTreeItem?>, IRequestHandler<GetMuscleRequest, IMuscleTreeItem[]>
{
    private readonly AppDbContext _dbContext;

    public MusclesRequestHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateMuscleRequest request, CancellationToken cancellationToken)
    {
        var parentId = request.ParentId;

        // normalize name
        var name = NormalizeName(request.Name);

        // check if name is empty
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name can't be empty.", nameof(request));

        var filter = parentId is null
            ? MuscleSpecs.Root()
            : MuscleSpecs.Children(parentId.Value);
        var siblings = await _dbContext.Muscles
            .AsNoTracking()
            .Where(filter)
            .ToListAsync(cancellationToken);

        // check uniqueness among sibling nodes
        var existingNode = siblings.FirstOrDefault(x => x.Name.Equals(name));
        if (existingNode is not null)
            return existingNode.Id;

        // insert entry
        var newNode = new EfMuscle
        {
            Id = Guid.NewGuid(),
            Name = name
        };

        // insert connections: extend ancestor connections and insert the self connection
        var newNodeConnections = new List<EfMuscleConnection>
        {
            new()
            {
                AncestorId = newNode.Id,
                DescendantId = newNode.Id,
                Depth = 0
            }
        };

        if (parentId is not null)
        {
            var parentConnections = await _dbContext.MuscleConnections
                .AsNoTracking()
                .Where(x => x.DescendantId == parentId)
                .ToListAsync(cancellationToken);

            newNodeConnections.AddRange(
                parentConnections
                    .Select(x => new EfMuscleConnection
                    {
                        AncestorId = x.AncestorId,
                        DescendantId = newNode.Id,
                        Depth = x.Depth + 1
                    }));
        }

        await _dbContext.Muscles.AddAsync(newNode, cancellationToken);
        await _dbContext.MuscleConnections.AddRangeAsync(newNodeConnections, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return newNode.Id;
    }

    public Task<Unit> Handle(UpdateMuscleRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Unit> Handle(DeleteGroupRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IMuscleTreeItem?> Handle(GetMuscleByIdRequest request, CancellationToken cancellationToken)
    {
        var results = await Get(new[]
        {
            MuscleSpecs.ById(request.Id)
        }, cancellationToken);

        return results.FirstOrDefault();
    }

    public async Task<IMuscleTreeItem[]> Handle(GetMuscleRequest request, CancellationToken cancellationToken)
    {
        var results = await Get(new[]
        {
            MuscleSpecs.ByQuery(request.Query),
            MuscleSpecs.ByParentId(request.ParentId)
        }, cancellationToken);

        return results;
    }

    private async Task<IMuscleTreeItem[]> Get(IEnumerable<Expression<Func<EfMuscle, bool>>> filters,
        CancellationToken cancellationToken)
    {
        IQueryable<EfMuscle> queryable = _dbContext.Muscles
            .AsNoTracking()
            .Include(x => x.Ancestors!)
            .ThenInclude(x => x.Ancestor)
            .Include(x => x.Descendants);

        queryable = filters.Aggregate(queryable, (current, filter) => current.Where(filter));

        var items = await queryable.ToListAsync(cancellationToken);

        IMuscleTreeItem Map(EfMuscle source)
        {
            var ancestors = source.Ancestors!.OrderByDescending(x => x.Depth)
                .Select(x => x.Ancestor!.Name)
                .ToArray();
            var parentId = source.Ancestors!.FirstOrDefault(a => a.Depth == 1)?.AncestorId;
            var hasChildren = source.Descendants!.Any(d => d.Depth > 0);
            var path = string.Join("/", ancestors);

            return new MuscleTreeItem(source.Id, parentId, source.Name, path, hasChildren);
        }

        return items.Select(Map).ToArray();
    }

    private static string NormalizeName(string input)
    {
        return input
            .Trim()
            .RemoveLineBreaks()
            .RemoveDoubleSpaces();
    }
}