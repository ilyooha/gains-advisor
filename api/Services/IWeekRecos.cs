namespace Services;

public interface IWeekRecos
{
    IDictionary<DayOfWeek, IMoveSets[]> Plan { get; }
}