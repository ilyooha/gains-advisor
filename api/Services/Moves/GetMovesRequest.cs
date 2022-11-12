using MediatR;

namespace Services.Moves;

public record GetMovesRequest(string? Query = null) : IRequest<IMove[]>;