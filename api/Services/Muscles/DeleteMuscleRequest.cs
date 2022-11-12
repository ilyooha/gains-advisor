using MediatR;

namespace Services.Muscles;

public record DeleteMuscleRequest(Guid Id) : IRequest;