using MediatR;

using Microsoft.AspNetCore.Mvc;

using MoreLife.Application.DTOs;
using MoreLife.Application.Features.Users.Queries;

namespace MoreLife.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDto request)
    {
        var response = await _mediator.Send(new LoginQuery() { Email = request.Email,Password=request.Password });

        if (!response.Success)
        {
            return Unauthorized(response.Message);
        }

        return Ok(new { Token = response.Data.Token });
    }
}