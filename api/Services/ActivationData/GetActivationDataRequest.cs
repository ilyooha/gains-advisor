using MediatR;

namespace Services.ActivationData;

public record GetActivationDataRequest(Guid MoveId) : IRequest<IMuscleActivationData[]>;