using Services;

namespace Infrastructure.EfCore;

public record Muscle(Guid Id, Guid? ParentId, string Name, string Path, bool HasChildren) : IMuscle;