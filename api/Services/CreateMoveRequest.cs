using MediatR;

namespace Services;

public record CreateMoveRequest(string Name) : IRequest<Guid>;