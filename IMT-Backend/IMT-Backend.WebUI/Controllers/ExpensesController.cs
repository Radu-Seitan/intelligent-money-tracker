using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Expenses.Commands;
using IMT_Backend.Application.Expenses.Queries;
using IMT_Backend.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IMT_Backend.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(IEnumerable<ExpenseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetAllUserExpenses([FromRoute] string userId)
        {
            var query = new GetAllUserExpensesQuery
            {
                UserId = userId
            };
            var expenses = await _mediator.Send(query);
            return Ok(expenses);
        }

        [HttpGet("{userId}/{category}")]
        [ProducesResponseType(typeof(IEnumerable<ExpenseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetUserExpensesByCategory([FromRoute] string userId, [FromRoute] int category)
        {
            var query = new GetUserExpensesByCategoryQuery
            {
                UserId = userId,
                Category = (ExpenseCategory)category
            };

            var expenses = await _mediator.Send(query);
            return Ok(expenses);
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(IEnumerable<ExpenseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetAllExpenses()
        {
            var query = new GetAllExpensesQuery { };

            var expenses = await _mediator.Send(query);
            return Ok(expenses);
        }

        [HttpGet("all/{category}")]
        [ProducesResponseType(typeof(IEnumerable<ExpenseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<IncomeDto>>> GetAllExpensesByCategory([FromRoute] int category)
        {
            var query = new GetAllExpensesByCategoryQuery
            {
                Category = (ExpenseCategory)category
            };

            var expenses = await _mediator.Send(query);
            return Ok(expenses);
        }

        [HttpGet("stores/{storeId}")]
        [ProducesResponseType(typeof(IEnumerable<ExpenseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetAllStoreExpenses([FromRoute] int storeId)
        {
            var query = new GetAllStoreExpensesQuery
            {
                StoreId = storeId
            };
            var expenses = await _mediator.Send(query);
            return Ok(expenses);
        }

        [HttpGet("stores/{storeId}/{category}")]
        [ProducesResponseType(typeof(IEnumerable<ExpenseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetAllStoreExpenses([FromRoute] int storeId, [FromRoute] int category)
        {
            var query = new GetStoreExpensesByCategoryQuery
            {
                StoreId = storeId,
                Category = (ExpenseCategory)category
            };
            var expenses = await _mediator.Send(query);
            return Ok(expenses);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AddExpense([FromBody] ExpenseDto expense)
        {
            var command = new CreateExpenseCommand
            {
                Quantity = expense.Quantity,
                Category = expense.Category,
                UserId = expense.UserId,
                StoreId = expense.StoreId,
            };
            await _mediator.Send(command);

            return Ok();
        }
    }
}
