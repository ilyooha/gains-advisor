using MediatR;

namespace Services;

public record GetWeekRecosRequest(int? Workouts = null, int? HeavySets = null, Guid[]? MuscleGroup = null)
    : IRequest<IWeekRecos>;