using MediatR;

namespace Services.ActivationData;

public record SetActivationDataRequest(Guid MoveId, Guid MuscleId, int Rate) : IRequest;