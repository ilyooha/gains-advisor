using System.Linq.Expressions;
using Infrastructure.EfCore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.ActivationData;

namespace Infrastructure.EfCore;

public class ActivationDataRequestHandler : IRequestHandler<GetActivationDataRequest, IMuscleActivationData[]>,
    IRequestHandler<GetMuscleActivationDataRequest, IMuscleActivationData?>,
    IRequestHandler<SetActivationDataRequest, Unit>,
    IRequestHandler<DeleteActivationDataRequest>
{
    private readonly AppDbContext _dbContext;

    public ActivationDataRequestHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IMuscleActivationData[]> Handle(GetActivationDataRequest request,
        CancellationToken cancellationToken)
    {
        return await Get(new[]
        {
            MuscleActivationDataSpecs.ByMoveId(request.MoveId)
        }, cancellationToken);
    }

    public async Task<IMuscleActivationData?> Handle(GetMuscleActivationDataRequest request,
        CancellationToken cancellationToken)
    {
        var data = await Get(new[]
        {
            MuscleActivationDataSpecs.ByMoveAndMuscleId(request.MoveId, request.MuscleId)
        }, cancellationToken);

        return data.FirstOrDefault();
    }

    public async Task<Unit> Handle(SetActivationDataRequest request,
        CancellationToken cancellationToken)
    {
        var activationData = await _dbContext.MuscleActivationData
            .Where(MuscleActivationDataSpecs.ByMoveAndMuscleId(request.MoveId, request.MuscleId))
            .FirstOrDefaultAsync(cancellationToken);

        if (activationData is null)
        {
            activationData = new EfMuscleActivationData
            {
                MoveId = request.MoveId,
                MuscleId = request.MuscleId
            };

            await _dbContext.MuscleActivationData.AddAsync(activationData, cancellationToken);
        }

        activationData.Rate = request.Rate;

        return Unit.Value;
    }

    public async Task<Unit> Handle(DeleteActivationDataRequest request, CancellationToken cancellationToken)
    {
        var activationData = await _dbContext.MuscleActivationData
            .Where(MuscleActivationDataSpecs.ByMoveAndMuscleId(request.MoveId, request.MuscleId))
            .FirstOrDefaultAsync(cancellationToken);

        if (activationData is not null)
            _dbContext.MuscleActivationData.Remove(activationData);

        return Unit.Value;
    }

    private async Task<IMuscleActivationData[]> Get(IEnumerable<Expression<Func<EfMuscleActivationData, bool>>> filters,
        CancellationToken cancellationToken)
    {
        IQueryable<EfMuscleActivationData> queryable = _dbContext.MuscleActivationData
            .AsNoTracking()
            .Include(x => x.Muscle);

        queryable = filters.Aggregate(queryable, (current, filter) => current.Where(filter));

        var items = await queryable.ToListAsync(cancellationToken);

        return items.Select(Map).ToArray();
    }

    private static IMuscleActivationData Map(EfMuscleActivationData source)
    {
        return new MuscleActivationData(new Muscle(source.Muscle!.Id, source.Muscle.Name), source.Rate);
    }
}