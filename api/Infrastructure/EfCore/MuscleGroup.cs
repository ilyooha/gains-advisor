using Services;

namespace Infrastructure.EfCore;

public record MuscleGroup(Guid Id, Guid? ParentId, string Name, string Path, bool HasChildren) 
    : IMuscleGroup;