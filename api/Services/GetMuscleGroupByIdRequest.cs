using MediatR;

namespace Services;

public record GetMuscleGroupByIdRequest(Guid Id) : IRequest<IMuscleGroup?>;