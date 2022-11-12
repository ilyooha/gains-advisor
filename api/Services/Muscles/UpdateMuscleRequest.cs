using MediatR;

namespace Services.Muscles;

public record UpdateMuscleRequest(Guid Id, string Name, Guid? ParentId = null) : IRequest;