using Services.Moves;

namespace Services;

public interface IMoveSets
{
    IMove Move { get; }
    int Sets { get; }
}