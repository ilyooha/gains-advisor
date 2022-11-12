using Services;

namespace Infrastructure.EfCore;

public record MuscleTreeItem(Guid Id, Guid? ParentId, string Name, string Path, bool HasChildren) : IMuscleTreeItem;