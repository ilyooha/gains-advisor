using MediatR;

namespace Services.Muscles;

public record GetMuscleByIdRequest(Guid Id) : IRequest<IMuscleTreeItem?>;