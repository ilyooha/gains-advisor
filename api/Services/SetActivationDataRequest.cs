using MediatR;

namespace Services;

public record SetActivationDataRequest(Guid MoveId, Guid MuscleId, int Rate) : IRequest;