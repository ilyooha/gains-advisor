using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace API.Controllers;

[ApiController]
[Route("api/v1/recos")]
public class RecosController : ControllerBase
{
    private readonly IMediator _mediator;

    public RecosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("week")]
    public async Task<IActionResult> GetWeekRecos([FromQuery] GetWeekRecosRequest request,
        CancellationToken cancellationToken = default)
    {
        var recos = await _mediator.Send(request, cancellationToken);
        return Ok(recos);
    }
}