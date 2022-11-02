using System.Linq.Expressions;

namespace Infrastructure;

public static class MoveSpecs
{
    public static Expression<Func<EfMove, bool>> ByQuery(string? query)
    {
        var q = query?.Trim().ToLower();

        return string.IsNullOrWhiteSpace(q) ? x => true : x => x.Name.ToLower().StartsWith(q);
    }

    public static Expression<Func<EfMove, bool>> ById(Guid id)
    {
        return x => x.Id == id;
    }

    public static Expression<Func<EfMove, bool>> ByName(string name)
    {
        return x => x.Name.Equals(name);
    }
}