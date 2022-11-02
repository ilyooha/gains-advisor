using MediatR;

namespace Services;

public record UpdateMoveRequest(Guid Id, string Name) : IRequest;