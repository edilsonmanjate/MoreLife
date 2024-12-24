using MediatR;

using Microsoft.AspNetCore.Mvc;

using MoreLife.Application.Features.Dashboards.Queries;

namespace MoreLife.API.Controllers;

[ApiController]
[Route("api/dashboards")]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetDashboard(CancellationToken cancellationToken)
    {
        var dashboard = await _mediator.Send(new GetDashboardQuery(), cancellationToken);
        return Ok(dashboard);
    }
}
