using Infrastructure.EfCore.Models.Classification;

namespace Infrastructure.EfCore.Models;

public class EfMuscleGroupConnection : IClassifierConnection<EfMuscleGroup>
{
    public Guid AncestorId { get; set; }
    public EfMuscleGroup? Ancestor { get; set; }
    public Guid DescendantId { get; set; }
    public EfMuscleGroup? Descendant { get; set; }
    public int Depth { get; set; }
}