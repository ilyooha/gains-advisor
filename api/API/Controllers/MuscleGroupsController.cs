using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace API.Controllers;

[ApiController]
[Route("api/v1/muscle-groups")]
public class MuscleGroupsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MuscleGroupsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetMuscleGroupsRequest request,
        CancellationToken cancellationToken = default)
    {
        var groups = await _mediator.Send(request, cancellationToken);
        return Ok(groups);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var group = await _mediator.Send(new GetMuscleGroupByIdRequest(id), cancellationToken);
        return Ok(group);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MuscleGroupPayload payload,
        CancellationToken cancellationToken = default)
    {
        var id = await _mediator.Send(new CreateMuscleGroupRequest(payload.Name, payload.ParentId), cancellationToken);
        return await GetOne(id, cancellationToken);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] MuscleGroupPayload payload,
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new UpdateMuscleGroupRequest(id, payload.Name, payload.ParentId), cancellationToken);
        return await GetOne(id, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new DeleteMuscleGroupRequest(id), cancellationToken);
        return Ok();
    }
}