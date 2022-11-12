using Services;
using Services.ActivationData;
using Services.Muscles;

namespace Infrastructure.EfCore;

public record MuscleActivationData(IMuscle Muscle, int Rate) : IMuscleActivationData;