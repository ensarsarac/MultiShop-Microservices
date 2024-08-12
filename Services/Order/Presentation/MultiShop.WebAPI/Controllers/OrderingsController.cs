using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Application.Features.Mediator.Results.OrderingResults;

namespace MultiShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetOrderingQueryResult());
            return Ok(values);
        }
		[HttpGet("GetOrderingByUserId/{id}")]
		public async Task<IActionResult> GetOrderingByUserId(string id)
		{
			var values = await _mediator.Send(new GetOrderingByUserIdQuery { UserId = id});
			return Ok(values);
		}
		[HttpGet("{id}")]
        public async Task<IActionResult> OrderingById(int id)
        {
            var values = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand createOrderingCommand)
        {
            await _mediator.Send(createOrderingCommand);
            return Ok("Kayıt başarılı bir şekilde eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand updateOrderingCommand)
        {
            await _mediator.Send(updateOrderingCommand);
            return Ok("Kayıt başarılı bir şekilde güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Kayıt başarılı bir şekilde silindi.");
        }
    }
}
