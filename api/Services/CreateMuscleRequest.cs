using MediatR;

namespace Services;

public record CreateMuscleRequest(string Name, Guid? ParentId = null) : IRequest<Guid>;