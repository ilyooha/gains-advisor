namespace Services.Muscles;

public interface IMuscleTreeItem
{
    Guid Id { get; }
    Guid? ParentId { get; }
    string Name { get; }
    string Path { get; }
    bool HasChildren { get; }
}