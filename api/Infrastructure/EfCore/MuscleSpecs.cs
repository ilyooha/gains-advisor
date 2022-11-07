using System.Linq.Expressions;
using Infrastructure.EfCore.Models;

namespace Infrastructure.EfCore;

public static class MuscleSpecs
{
    public static Expression<Func<EfMuscle, bool>> ById(Guid id)
    {
        return g => g.Id == id;
    }

    public static Expression<Func<EfMuscle, bool>> ByIds(Guid[] ids)
    {
        return g => ids.Contains(g.Id);
    }

    public static Expression<Func<EfMuscle, bool>> Root()
    {
        return g => !g.Ancestors!.Any(a => a.Depth > 0);
    }

    public static Expression<Func<EfMuscle, bool>> Children(Guid parentId)
    {
        return g => g.Ancestors!.Any(a => a.Depth == 1 && a.AncestorId == parentId);
    }

    public static Expression<Func<EfMuscle, bool>> ByQuery(string? query)
    {
        var q = query?.Trim().ToLower();

        return string.IsNullOrEmpty(q) ? x => true : x => x.Name.ToLower().StartsWith(q);
    }

    public static Expression<Func<EfMuscle, bool>> ByParentId(Guid? parentId)
    {
        return parentId is null
            ? x => !x.Ancestors!.Any(a => a.Depth > 0)
            : x => x.Ancestors!.Any(a => a.Depth == 1 && a.AncestorId == parentId);
    }
}