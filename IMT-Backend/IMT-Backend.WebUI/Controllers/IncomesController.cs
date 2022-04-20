using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Incomes.Commands;
using IMT_Backend.Application.Incomes.Queries;
using IMT_Backend.Domain.Enums;
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

        [HttpGet("{userId}/{category}")]
        [ProducesResponseType(typeof(IEnumerable<IncomeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<IncomeDto>>> GetUserIncomesByCategory([FromRoute] string userId, [FromRoute] int category)
        {
            var query = new GetUserIncomesByCategoryQuery
            {
                UserId = userId,
                Category = (IncomeCategory)category
            };

            var incomes = await _mediator.Send(query);
            return Ok(incomes);
        }

        [HttpGet("all/{category}")]
        [ProducesResponseType(typeof(IEnumerable<IncomeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<IncomeDto>>> GetAllIncomesByCategory([FromRoute] int category)
        {
            var query = new GetAllIncomesByCategoryQuery
            {
                Category = (IncomeCategory)category
            };

            var incomes = await _mediator.Send(query);
            return Ok(incomes);
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
