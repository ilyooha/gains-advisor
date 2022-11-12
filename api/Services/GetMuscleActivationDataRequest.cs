using MediatR;

namespace Services;

public record GetMuscleActivationDataRequest(Guid MoveId, Guid MuscleId) : IRequest<IMuscleActivationData?>;