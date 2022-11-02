using MediatR;

namespace Services;

public record GetMovesRequest(string? Query = null) : IRequest<IMove[]>;