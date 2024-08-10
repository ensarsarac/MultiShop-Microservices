using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Dtos;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _context.UserComments.ToList();
            return Ok(values);
        }
        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var values = _context.UserComments.Where(x=>x.ProductId == id).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(CreateCommentDto createCommentDto)
        {
            var comment = new UserComment() 
            {
                NameSurname = createCommentDto.NameSurname,
                CommentDetail = createCommentDto.CommentDetail,
                ImageUrl = createCommentDto.ImageUrl,
                CreatedDate = createCommentDto.CreatedDate,
                Email = createCommentDto.Email,
                Rating = createCommentDto.Rating,
                Status = createCommentDto.Status,
                ProductId = createCommentDto.ProductId,
            };
            _context.UserComments.Add(comment);
            _context.SaveChanges();
            return Ok("Yorum başarılı bir şekilde eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _context.UserComments.Where(x=>x.UserCommentId == id).FirstOrDefault();
            _context.UserComments.Remove(value);
            _context.SaveChanges();
            return Ok("Yorum başarılı bir şekilde silindi.");
        }
        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            //var value = _context.UserComments.Where(x=>x.UserCommentId == userComment.UserCommentId).FirstOrDefault();
            _context.UserComments.Update(userComment);
            _context.SaveChanges();
            return Ok("Yorum başarılı bir şekilde güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdComment(int id)
        {
            var values = _context.UserComments.Where(x=>x.UserCommentId==id).FirstOrDefault();
            return Ok(values);
        }
    }
}
