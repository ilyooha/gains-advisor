using MediatR;

namespace Services.Muscles;

public record CreateMuscleRequest(string Name, Guid? ParentId = null) : IRequest<Guid>;