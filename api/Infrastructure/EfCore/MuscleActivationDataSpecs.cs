using System.Linq.Expressions;
using Infrastructure.EfCore.Models;

namespace Infrastructure.EfCore;

public static class MuscleActivationDataSpecs
{
    public static Expression<Func<EfMuscleActivationData, bool>> ByMoveId(Guid moveId)
    {
        return x => x.MoveId == moveId;
    }

    public static Expression<Func<EfMuscleActivationData, bool>> ByMoveAndMuscleId(Guid moveId, Guid muscleId)
    {
        return x => x.MoveId == moveId && x.MuscleId == muscleId;
    }
}