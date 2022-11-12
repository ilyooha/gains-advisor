using Services;
using Services.Muscles;

namespace Infrastructure.EfCore;

public record Muscle(Guid Id, string Name) : IMuscle;