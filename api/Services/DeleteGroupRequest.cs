using MediatR;

namespace Services;

public record DeleteGroupRequest(Guid Id) : IRequest;