using MediatR;

namespace Services;

public record GetWeekRecosRequest(int? Workouts = null, int? HeavySets = null, Guid[]? Muscle = null)
    : IRequest<IWeekRecos>;