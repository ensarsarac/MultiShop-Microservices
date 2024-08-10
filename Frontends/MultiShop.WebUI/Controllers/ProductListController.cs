using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly ICommentService _commentService;
                
        public ProductListController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index(string? id)
        {
            ViewBag.id = id;
            return View();
        }
        public IActionResult ProductDetail(string id)
        {
            ViewBag.productId = id;
            TempData["id"] = id;
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.Status = true;
            createCommentDto.CreatedDate = DateTime.Now;
            createCommentDto.ProductId = TempData["id"].ToString();
            createCommentDto.Rating = 5;
            createCommentDto.ImageUrl = string.Empty;
            await _commentService.CreateCommentAsync(createCommentDto);
            return RedirectToAction("Index","Default");
        }
    }
}
