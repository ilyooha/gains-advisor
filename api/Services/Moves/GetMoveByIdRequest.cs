using MediatR;

namespace Services.Moves;

public record GetMoveByIdRequest(Guid Id) : IRequest<IMove?>;