using MediatR;

using Microsoft.AspNetCore.Mvc;

using MoreLife.Application.Features.BloodStocks.Queries.GetAllBloodStocksQuery;
using MoreLife.Application.Features.BloodStocks.Queries.GetBloodStockByBloodTypeQuerys;

namespace MoreLife.API.Controllers
{
    [ApiController]
    [Route("api/BloodStock")]
    public class BloodStockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BloodStockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetByBloodType")]
        public async Task<IActionResult> GetAsync([FromQuery] string bloodType, string rhFactor)
        {
            var response = await _mediator.Send(new GetBloodStockByBloodTypeQuery() { bloodType = bloodType, rhFactor = rhFactor });
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllBloodStocksQuery());
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
