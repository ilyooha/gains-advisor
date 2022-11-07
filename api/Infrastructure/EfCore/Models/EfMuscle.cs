using Infrastructure.EfCore.Models.Classification;

namespace Infrastructure.EfCore.Models;

public class EfMuscle : IClassifier<EfMuscleConnection>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public ICollection<EfMuscleConnection>? Ancestors { get; set; }
    public ICollection<EfMuscleConnection>? Descendants { get; set; }
    public ICollection<EfMuscleActivationData>? Moves { get; set; }
}