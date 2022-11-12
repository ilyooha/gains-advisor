using Services;

namespace Infrastructure.EfCore;

public record MuscleActivationData(IMuscle Muscle, int Rate) : IMuscleActivationData;