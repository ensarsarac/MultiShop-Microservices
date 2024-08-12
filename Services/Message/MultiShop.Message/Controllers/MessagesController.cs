using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            await _messageService.CreateMessageAsync(createMessageDto);

            return Ok("Kayıt başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _messageService.DeleteMessageAsync(id);

            return Ok("Kayıt başarıyla silindi");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var values = await _messageService.GetAllMessageAsync();

            return Ok(values);
        }
        [HttpGet("GetInboxMessageList/{id}")]
        public async Task<IActionResult> GetInboxMessageList(string id)
        {
            var values = await _messageService.GetInboxMessage(id);

            return Ok(values);
        }

        [HttpGet("GetSendBoxMessageList/{id}")]
        public async Task<IActionResult> GetSendBoxMessageList(string id)
        {
            var values = await _messageService.GetSendboxMessage(id);

            return Ok(values);
        }
        [HttpGet("GetByIdMessage/{id}")]
        public async Task<IActionResult> GetByIdMessage(int id)
        {
            var values = await _messageService.GetByIdMessage(id);

            return Ok(values);
        }
    }
}
