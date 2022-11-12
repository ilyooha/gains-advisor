namespace Services;

public interface IMuscleActivationData
{
    IMuscle Muscle { get; }
    int Rate { get; }
}