using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRU.Application.DTOs;
using ShopsRU.Application.Features.Commands;

namespace ShopsRU.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("BuyProduct")]
        public async Task<IActionResult> BuyProduct([FromBody] UserDto request)
        {
            await _mediator.Send(new ProductBuyCommand() { Amount = request.Amount, IsGrocery = request.IsGrocery, UserId = request.Id });
            return Ok();
        }
    }
}
