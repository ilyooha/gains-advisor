namespace Infrastructure.EfCore.Models;

public class EfMuscleActivationData
{
    public Guid MoveId { get; set; }
    public EfMove? Move { get; set; }
    public Guid MuscleId { get; set; }
    public EfMuscle? Muscle { get; set; }
    public int Rate { get; set; }
}