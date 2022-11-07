using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace API.Controllers;

[ApiController]
[Route("api/v1/muscles")]
public class MusclesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MusclesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetMuscleRequest request,
        CancellationToken cancellationToken = default)
    {
        var groups = await _mediator.Send(request, cancellationToken);
        return Ok(groups);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var group = await _mediator.Send(new GetMuscleByIdRequest(id), cancellationToken);
        return Ok(group);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MusclePayload payload,
        CancellationToken cancellationToken = default)
    {
        var id = await _mediator.Send(new CreateMuscleRequest(payload.Name, payload.ParentId), cancellationToken);
        return await GetOne(id, cancellationToken);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] MusclePayload payload,
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new UpdateMuscleRequest(id, payload.Name, payload.ParentId), cancellationToken);
        return await GetOne(id, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new DeleteGroupRequest(id), cancellationToken);
        return Ok();
    }
}