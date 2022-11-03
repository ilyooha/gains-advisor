using MediatR;

namespace Services;

public record UpdateMuscleGroupRequest(Guid Id, string Name, Guid? ParentId = null) : IRequest;