using MediatR;

namespace Services;

public record UpdateMuscleRequest(Guid Id, string Name, Guid? ParentId = null) : IRequest;