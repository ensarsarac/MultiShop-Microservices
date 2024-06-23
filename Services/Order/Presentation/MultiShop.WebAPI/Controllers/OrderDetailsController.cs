using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailByIdQueryResultHandler _getOrderDetailByIdQueryResultHandler;
        private readonly GetOrderDetailQueryResultHandler _getOrderDetailQueryResultHandler;
        private readonly CreateOrderDetailsHandler _createOrderDetailsHandler;
        private readonly UpdateOrderDetailHandler _updateOrderDetailHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

        public OrderDetailsController(GetOrderDetailByIdQueryResultHandler getOrderDetailByIdQueryResultHandler, GetOrderDetailQueryResultHandler getOrderDetailQueryResultHandler, CreateOrderDetailsHandler createOrderDetailsHandler, UpdateOrderDetailHandler updateOrderDetailHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
        {
            _getOrderDetailByIdQueryResultHandler = getOrderDetailByIdQueryResultHandler;
            _getOrderDetailQueryResultHandler = getOrderDetailQueryResultHandler;
            _createOrderDetailsHandler = createOrderDetailsHandler;
            _updateOrderDetailHandler = updateOrderDetailHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _getOrderDetailQueryResultHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ByIdOrderDetail(int id)
        {
            var values =await _getOrderDetailByIdQueryResultHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _createOrderDetailsHandler.Handle(createOrderDetailCommand);
            return Ok("Kayıt başarılı bir şekilde eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            await _updateOrderDetailHandler.Handle(updateOrderDetailCommand);
            return Ok("Kayıt başarılı bir şekilde güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(RemoveOrderDetailCommand deleteOrderDetailCommand)
        {
            await _removeOrderDetailCommandHandler.Handle(deleteOrderDetailCommand);
            return Ok("Kayıt başarılı bir şekilde silindi.");
        }
    }
}
