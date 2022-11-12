namespace Infrastructure.EfCore.Models;

public class EfMove
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public ICollection<EfMuscleActivationData>? ActivationData { get; set; }
}