using Services;

namespace Infrastructure;

public record Move(Guid Id, string Name) : IMove;