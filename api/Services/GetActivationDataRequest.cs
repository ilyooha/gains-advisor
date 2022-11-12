using MediatR;

namespace Services;

public record GetActivationDataRequest(Guid MoveId) : IRequest<IMuscleActivationData[]>;