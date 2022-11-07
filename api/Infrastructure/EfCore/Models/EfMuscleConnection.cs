using Infrastructure.EfCore.Models.Classification;

namespace Infrastructure.EfCore.Models;

public class EfMuscleConnection : IClassifierConnection<EfMuscle>
{
    public Guid AncestorId { get; set; }
    public EfMuscle? Ancestor { get; set; }
    public Guid DescendantId { get; set; }
    public EfMuscle? Descendant { get; set; }
    public int Depth { get; set; }
}