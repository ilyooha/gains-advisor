namespace Services.Moves;

public interface IMove
{
    Guid Id { get; }
    string Name { get; }
}