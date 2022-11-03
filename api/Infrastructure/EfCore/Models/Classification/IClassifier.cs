namespace Infrastructure.EfCore.Models.Classification;

public interface IClassifier<T>
{
    Guid Id { get; }
    string Name { get; }
    ICollection<T>? Ancestors { get; }
    ICollection<T>? Descendants { get; }
}