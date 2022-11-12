using MediatR;

namespace Services;

public record GetMuscleByIdRequest(Guid Id) : IRequest<IMuscleTreeItem?>;