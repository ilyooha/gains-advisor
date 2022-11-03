using Infrastructure.EfCore.Models.Classification;

namespace Infrastructure.EfCore.Models;

public class EfMuscleGroup : IClassifier<EfMuscleGroupConnection>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public ICollection<EfMuscleGroupConnection>? Ancestors { get; set; }
    public ICollection<EfMuscleGroupConnection>? Descendants { get; set; }
}