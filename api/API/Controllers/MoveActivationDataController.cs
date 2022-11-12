using API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.ActivationData;

namespace API.Controllers;

[ApiController]
[Route("api/v1/moves/{moveId:guid}/muscles")]
public class MoveActivationDataController : ControllerBase
{
    private readonly IMediator _mediator;

    public MoveActivationDataController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] Guid moveId, CancellationToken cancellationToken = default)
    {
        var activationData = await _mediator.Send(
            new GetActivationDataRequest(moveId), cancellationToken);

        return Ok(activationData);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromRoute] Guid moveId, [FromBody] ActivationDataPayload payload,
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new SetActivationDataRequest(moveId, payload.MuscleId, payload.Rate), cancellationToken);

        return await GetOne(moveId, payload.MuscleId, cancellationToken);
    }

    [HttpGet("{muscleId:guid}")]
    public async Task<IActionResult> GetOne([FromRoute] Guid moveId, [FromRoute] Guid muscleId,
        CancellationToken cancellationToken = default)
    {
        var activationData =
            await _mediator.Send(new GetMuscleActivationDataRequest(moveId, muscleId), cancellationToken);

        return Ok(activationData);
    }

    [HttpPut("{muscleId:guid}")]
    public async Task<IActionResult> Put([FromRoute] Guid moveId, [FromRoute] Guid muscleId,
        [FromBody] MuscleActivationDataPayload payload, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new SetActivationDataRequest(moveId, muscleId, payload.Rate), cancellationToken);

        return await GetOne(moveId, muscleId, cancellationToken);
    }

    [HttpDelete("{muscleId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid moveId, [FromRoute] Guid muscleId,
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new DeleteActivationDataRequest(moveId, muscleId), cancellationToken);

        return Ok();
    }
}