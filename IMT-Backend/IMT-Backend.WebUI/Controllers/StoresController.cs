using IMT_Backend.Application.Common.DTOs;
using IMT_Backend.Application.Stores.Commands;
using IMT_Backend.Application.Stores.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IMT_Backend.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoresController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{storeId}")]
        [ProducesResponseType(typeof(StoreDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StoreDto>> GetStore([FromRoute] int storeId)
        {
            var query = new GetStoreQuery { StoreId = storeId };
            var store = await _mediator.Send(query);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StoreDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<StoreDto>>> GetUsers()
        {
            var query = new GetAllStoresQuery { };
            var stores = await _mediator.Send(query);
            if (stores == null)
            {
                return NotFound();
            }
            return Ok(stores);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AddStore([FromBody] StoreDto store)
        {
            var command = new CreateStoreCommand
            {
                Name = store.Name
            };
            await _mediator.Send(command);

            return Ok();
        }
    }
}
