using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.DAL.Concrete;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class MessasgeStatisticController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessasgeStatisticController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalMessage()
        {
            int messageCount = await _messageService.TotalMessageCount();
            return Ok(messageCount);
        }
    }
}
