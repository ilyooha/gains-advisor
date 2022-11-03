namespace Services;

public interface IMuscleGroup
{
    Guid Id { get; }
    Guid? ParentId { get; }
    string Name { get; }
    string Path { get; }
    bool HasChildren { get; }
}