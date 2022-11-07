namespace Services;

public interface IMuscle
{
    Guid Id { get; }
    Guid? ParentId { get; }
    string Name { get; }
    string Path { get; }
    bool HasChildren { get; }
}