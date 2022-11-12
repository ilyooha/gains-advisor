using MediatR;

namespace Services.Muscles;

public record GetMuscleRequest(string? Query = null, Guid? ParentId = null)
    : IRequest<IMuscleTreeItem[]>;