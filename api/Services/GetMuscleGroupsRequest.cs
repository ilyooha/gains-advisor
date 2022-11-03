using MediatR;

namespace Services;

public record GetMuscleGroupsRequest(string? Query = null, Guid? ParentId = null)
    : IRequest<IMuscleGroup[]>;