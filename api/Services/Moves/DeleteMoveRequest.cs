using MediatR;

namespace Services.Moves;

public record DeleteMoveRequest(Guid Id) : IRequest;