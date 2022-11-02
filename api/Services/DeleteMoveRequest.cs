using MediatR;

namespace Services;

public record DeleteMoveRequest(Guid Id) : IRequest;