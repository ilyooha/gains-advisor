using MediatR;

namespace Services;

public record DeleteMuscleGroupRequest(Guid Id) : IRequest;