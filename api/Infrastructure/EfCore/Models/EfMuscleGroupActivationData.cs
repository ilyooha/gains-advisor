namespace Infrastructure.EfCore.Models;

public class EfMuscleGroupActivationData
{
    public Guid MoveId { get; set; }
    public EfMove? Move { get; set; }
    public Guid MuscleGroupId { get; set; }
    public EfMuscleGroup? MuscleGroup { get; set; }
    // TODO: public int ActivationRate { get; set; }
}