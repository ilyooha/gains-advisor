using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Moves;

namespace API.Controllers;

[ApiController]
[Route("api/v1/moves")]
public class MovesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MovesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetMovesRequest request,
        CancellationToken cancellationToken = default)
    {
        var move = await _mediator.Send(request, cancellationToken);
        return Ok(move);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOne([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var move = await _mediator.Send(new GetMoveByIdRequest(id), cancellationToken);
        return Ok(move);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MovePayload payload,
        CancellationToken cancellationToken = default)
    {
        var id = await _mediator.Send(new CreateMoveRequest(payload.Name), cancellationToken);
        return await GetOne(id, cancellationToken);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] MovePayload payload,
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new UpdateMoveRequest(id, payload.Name), cancellationToken);
        return await GetOne(id, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new DeleteMoveRequest(id), cancellationToken);
        return Ok();
    }
}