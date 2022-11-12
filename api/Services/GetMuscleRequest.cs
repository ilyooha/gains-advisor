using MediatR;

namespace Services;

public record GetMuscleRequest(string? Query = null, Guid? ParentId = null)
    : IRequest<IMuscleTreeItem[]>;