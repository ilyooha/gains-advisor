using Services;
using Services.Moves;

namespace Infrastructure;

public record Move(Guid Id, string Name) : IMove;