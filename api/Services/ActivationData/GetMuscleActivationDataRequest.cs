using MediatR;

namespace Services.ActivationData;

public record GetMuscleActivationDataRequest(Guid MoveId, Guid MuscleId) : IRequest<IMuscleActivationData?>;