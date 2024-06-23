using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
            var client = _httpClientFactory.CreateClient();
            var values = JsonConvert.SerializeObject(createCommentDto);
            var content = new StringContent(values,Encoding.UTF8,"application/json");
            await client.PostAsync("https://localhost:7255/api/Comments", content);
            return RedirectToAction("Index","Default");
        }
    }
}
