using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;

namespace MultiShop.Comment.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentStatisticController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentStatisticController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet("GetCommentCount")]
        public async Task<IActionResult> GetCommentCount()
        {
            int value =await _commentContext.UserComments.CountAsync();
            return Ok(value);
        }

    }
}
