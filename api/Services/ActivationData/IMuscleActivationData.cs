using Services.Muscles;

namespace Services.ActivationData;

public interface IMuscleActivationData
{
    IMuscle Muscle { get; }
    int Rate { get; }
}