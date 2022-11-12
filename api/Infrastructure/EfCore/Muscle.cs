using Services;

namespace Infrastructure.EfCore;

public record Muscle(Guid Id, string Name) : IMuscle;