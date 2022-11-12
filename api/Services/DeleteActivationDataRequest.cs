using MediatR;

namespace Services;

public record DeleteActivationDataRequest(Guid MoveId, Guid MuscleId) : IRequest;