using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MoreLife.Application.Features.Donations.Command.CreateDonationCommand;
using MoreLife.Application.Features.Donations.Command.DeleteDonationCommand;
using MoreLife.Application.Features.Donations.Command.UpdateDonationCommand;
using MoreLife.Application.Features.Donations.Queries.GetAllDonationsQuery;
using MoreLife.Application.Features.Donations.Queries.GetDonationByIdQuery;

namespace MoreLife.API.Controllers;

[ApiController]
[Route("api/donations")]
[Authorize]

public class DonationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _mediator.Send(new GetAllDonationsQuery());
        if (response.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetAsync([FromQuery] Guid donatorId)
    {
        var response = await _mediator.Send(new GetDonationByIdQuery() { Id = donatorId });
        if (response.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }

    [HttpPost("Create")]
    public async Task<ActionResult> Create([FromBody] CreateDonationCommand command, CancellationToken cancellationToken)
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
    public async Task<ActionResult> UpdateAsync([FromBody] UpdatedDonationCommand command, CancellationToken cancellationToken)
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
    public async Task<ActionResult> DeleteAsync([FromQuery] DeleteDonationCommand command, CancellationToken cancellationToken)
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
