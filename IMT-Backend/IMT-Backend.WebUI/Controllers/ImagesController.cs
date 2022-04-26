using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Application.Images.Commands;
using IMT_Backend.Application.Images.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMT_Backend.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ImagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{storeId}")]
        public async Task<IActionResult> Post(IFormFile file, int storeId)
        {
            if (file != null)
            {
                if (file.Length > 0)
                {
                    byte[] content = null;
                    using (var fileStream = file.OpenReadStream())
                    using (var memoryStream = new MemoryStream())
                    {
                        fileStream.CopyTo(memoryStream);
                        content = memoryStream.ToArray();
                    }

                    var command = new UploadImageCommand
                    {
                        Content = content,
                        Type = file.ContentType,
                        StoreId = storeId
                    };
                    var imageId = await _mediator.Send(command);
                    return Ok(imageId);
                }
                else return BadRequest("file length");
            }
            else return BadRequest("file[0] is null");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var query = new GetImageQuery
            {
                ImageId = id
            };
            var image = await _mediator.Send(query);

            return File(image.Content, $"{image.Type}");
        }
    }
}
