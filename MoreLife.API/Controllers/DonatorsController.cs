using MediatR;

using Microsoft.AspNetCore.Mvc;

using MoreLife.Application.Features.Donators.Command.CreateDonatorCommand;
using MoreLife.Application.Features.Donators.Command.DeleteDonatorCommand;
using MoreLife.Application.Features.Donators.Command.UpdateDonatorCommand;
using MoreLife.Application.Features.Donators.Queries.GetAllDonatorsQuery;
using MoreLife.Application.Features.Donators.Queries.GetDonatorByIdQuery;

namespace MoreLife.API.Controllers;

[ApiController]
[Route("api/donators")]
public class DonatorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonatorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _mediator.Send(new GetAllDonatorQuery());
        if (response.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetAsync([FromQuery] Guid donatorId)
    {
        var response = await _mediator.Send(new GetDonatorByIdQuery() { Id = donatorId });
        if (response.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }

    [HttpPost("Create")]
    public async Task<ActionResult> Create([FromBody] CreateDonatorCommand command, CancellationToken cancellationToken)
    {
        if (command is null) return BadRequest();

        var response = await _mediator.Send(command, cancellationToken);

        if (response.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }


    [HttpPut("Update")]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateDonatorCommand command, CancellationToken cancellationToken)
    {
        if (command is null) return BadRequest();

        var response = await _mediator.Send(command, cancellationToken);

        if (response.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult> DeleteAsync([FromQuery] DeleteDonatorCommand command, CancellationToken cancellationToken)
    {
        if (command is null) return BadRequest();

        var response = await _mediator.Send(command, cancellationToken);

        if (response.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}
