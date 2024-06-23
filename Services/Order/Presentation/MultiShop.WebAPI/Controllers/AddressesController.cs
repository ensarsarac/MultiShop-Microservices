using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryResultHandler _queryHandler;
        private readonly GetAddressByIdQueryResultHandler _getAddressByIdQueryResultHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly DeleteAddressCommandHandler _deleteAddressCommandHandler;

        public AddressesController(GetAddressQueryResultHandler queryHandler, GetAddressByIdQueryResultHandler getAddressByIdQueryResultHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, DeleteAddressCommandHandler deleteAddressCommandHandler)
        {
            _queryHandler = queryHandler;
            _getAddressByIdQueryResultHandler = getAddressByIdQueryResultHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _deleteAddressCommandHandler = deleteAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _queryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ByIdAddress(int id)
        {
            var values = await _getAddressByIdQueryResultHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand createAddressCommand)
        {
            await _createAddressCommandHandler.Handle(createAddressCommand);
            return Ok("Kayıt başarılı bir şekilde eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
        {
            await _updateAddressCommandHandler.Handle(updateAddressCommand);
            return Ok("Kayıt başarılı bir şekilde güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(DeleteAddressCommand deleteAddressCommand)
        {
            await _deleteAddressCommandHandler.Handle(deleteAddressCommand);
            return Ok("Kayıt başarılı bir şekilde silindi.");
        }
    }
}
