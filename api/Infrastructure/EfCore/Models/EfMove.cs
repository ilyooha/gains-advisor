namespace Infrastructure.EfCore.Models;

public class EfMove
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public ICollection<EfMuscleActivationData>? ActivationData { get; set; }
}

// quadriceps
// - quad1
// - quad2
// - quad3
// - quad4

// movement
// activation rates:
// - quad1: 54
// - quad4: 21