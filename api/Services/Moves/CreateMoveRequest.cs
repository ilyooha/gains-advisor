using MediatR;

namespace Services.Moves;

public record CreateMoveRequest(string Name) : IRequest<Guid>;