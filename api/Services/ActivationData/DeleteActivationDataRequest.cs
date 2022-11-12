using MediatR;

namespace Services.ActivationData;

public record DeleteActivationDataRequest(Guid MoveId, Guid MuscleId) : IRequest;