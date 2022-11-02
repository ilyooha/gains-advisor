using MediatR;

namespace Services;

public record GetMoveByIdRequest(Guid Id) : IRequest<IMove?>;