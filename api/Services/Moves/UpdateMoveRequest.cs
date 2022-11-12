using MediatR;

namespace Services.Moves;

public record UpdateMoveRequest(Guid Id, string Name) : IRequest;