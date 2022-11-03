using System.Linq.Expressions;
using Infrastructure.EfCore.Models;

namespace Infrastructure.EfCore;

public static class MuscleGroupSpecs
{
    public static Expression<Func<EfMuscleGroup, bool>> ById(Guid id)
    {
        return g => g.Id == id;
    }

    public static Expression<Func<EfMuscleGroup, bool>> Root()
    {
        return g => !g.Ancestors!.Any(a => a.Depth > 0);
    }

    public static Expression<Func<EfMuscleGroup, bool>> Children(Guid parentId)
    {
        return g => g.Ancestors!.Any(a => a.Depth == 1 && a.AncestorId == parentId);
    }

    public static Expression<Func<EfMuscleGroup, bool>> ByQuery(string? query)
    {
        var q = query?.Trim().ToLower();

        return string.IsNullOrEmpty(q) ? x => true : x => x.Name.ToLower().StartsWith(q);
    }

    public static Expression<Func<EfMuscleGroup, bool>> ByParentId(Guid? parentId)
    {
        return parentId is null
            ? x => !x.Ancestors!.Any(a => a.Depth > 0)
            : x => x.Ancestors!.Any(a => a.Depth == 1 && a.AncestorId == parentId);
    }
}