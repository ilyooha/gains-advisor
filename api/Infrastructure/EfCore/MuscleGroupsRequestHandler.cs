using System.Linq.Expressions;
using Infrastructure.EfCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Infrastructure.EfCore;

public class MuscleGroupsRequestHandler : IRequestHandler<CreateMuscleGroupRequest, Guid>,
    IRequestHandler<UpdateMuscleGroupRequest>, IRequestHandler<DeleteMuscleGroupRequest>,
    IRequestHandler<GetMuscleGroupByIdRequest, IMuscleGroup?>, IRequestHandler<GetMuscleGroupsRequest, IMuscleGroup[]>
{
    private readonly AppDbContext _dbContext;

    public MuscleGroupsRequestHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateMuscleGroupRequest request, CancellationToken cancellationToken)
    {
        var parentId = request.ParentId;

        // normalize name
        var name = NormalizeName(request.Name);

        // check if name is empty
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name can't be empty.", nameof(request));

        var filter = parentId is null
            ? MuscleGroupSpecs.Root()
            : MuscleGroupSpecs.Children(parentId.Value);
        var siblings = await _dbContext.MuscleGroups
            .AsNoTracking()
            .Where(filter)
            .ToListAsync(cancellationToken);

        // check uniqueness among sibling nodes
        var existingNode = siblings.FirstOrDefault(x => x.Name.Equals(name));
        if (existingNode is not null)
            return existingNode.Id;

        // insert entry
        var newNode = new EfMuscleGroup
        {
            Id = Guid.NewGuid(),
            Name = name
        };

        // insert connections: extend ancestor connections and insert the self connection
        var newNodeConnections = new List<EfMuscleGroupConnection>
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
            var parentConnections = await _dbContext.MuscleGroupConnections
                .AsNoTracking()
                .Where(x => x.DescendantId == parentId)
                .ToListAsync(cancellationToken);

            newNodeConnections.AddRange(
                parentConnections
                    .Select(x => new EfMuscleGroupConnection
                    {
                        AncestorId = x.AncestorId,
                        DescendantId = newNode.Id,
                        Depth = x.Depth + 1
                    }));
        }

        await _dbContext.MuscleGroups.AddAsync(newNode, cancellationToken);
        await _dbContext.MuscleGroupConnections.AddRangeAsync(newNodeConnections, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return newNode.Id;
    }

    public Task<Unit> Handle(UpdateMuscleGroupRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Unit> Handle(DeleteMuscleGroupRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IMuscleGroup?> Handle(GetMuscleGroupByIdRequest request, CancellationToken cancellationToken)
    {
        var results = await Get(new[]
        {
            MuscleGroupSpecs.ById(request.Id)
        }, cancellationToken);

        return results.FirstOrDefault();
    }

    public async Task<IMuscleGroup[]> Handle(GetMuscleGroupsRequest request, CancellationToken cancellationToken)
    {
        var results = await Get(new[]
        {
            MuscleGroupSpecs.ByQuery(request.Query),
            MuscleGroupSpecs.ByParentId(request.ParentId)
        }, cancellationToken);

        return results;
    }

    private async Task<IMuscleGroup[]> Get(IEnumerable<Expression<Func<EfMuscleGroup, bool>>> filters,
        CancellationToken cancellationToken)
    {
        IQueryable<EfMuscleGroup> queryable = _dbContext.MuscleGroups
            .AsNoTracking()
            .Include(x => x.Ancestors!)
            .ThenInclude(x => x.Ancestor)
            .Include(x => x.Descendants);

        queryable = filters.Aggregate(queryable, (current, filter) => current.Where(filter));

        var items = await queryable.ToListAsync(cancellationToken);

        IMuscleGroup Map(EfMuscleGroup source)
        {
            var ancestors = source.Ancestors!.OrderByDescending(x => x.Depth)
                .Select(x => x.Ancestor!.Name)
                .ToArray();
            var parentId = source.Ancestors!.FirstOrDefault(a => a.Depth == 1)?.AncestorId;
            var hasChildren = source.Descendants!.Any(d => d.Depth > 0);
            var path = string.Join("/", ancestors);

            return new MuscleGroup(source.Id, parentId, source.Name, path, hasChildren);
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