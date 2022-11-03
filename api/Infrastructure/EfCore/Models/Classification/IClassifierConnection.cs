namespace Infrastructure.EfCore.Models.Classification;

public interface IClassifierConnection<out T>
{
    Guid AncestorId { get; }
    T? Ancestor { get; }
    Guid DescendantId { get; }
    T? Descendant { get; }
    int Depth { get; }
}