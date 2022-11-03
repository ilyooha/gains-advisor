using MediatR;

namespace Services;

public record CreateMuscleGroupRequest(string Name, Guid? ParentId = null) : IRequest<Guid>;