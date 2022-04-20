using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Incomes.Commands;
using IMT_Backend.Application.Incomes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IMT_Backend.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IncomesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<double>> GetTotalIncome([FromRoute] string id)
        {
            var query = new GetUserTotalIncomeQuery { UserId = id };
            var total = await _mediator.Send(query);
            return Ok(total);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AddIncome([FromBody] IncomeDto income)
        {
            var command = new CreateIncomeCommand
            {
                Quantity = income.Quantity,
                Category = income.Category,
                UserId =  income.UserId,
            };
            await _mediator.Send(command);

            return Ok();
        }
    }
}
