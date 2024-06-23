using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7255/api/Comments");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultCommentDto>>(readData);
                return View(jsonData);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateComment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var values = JsonConvert.SerializeObject(createCommentDto);
            var content = new StringContent(values, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7255/api/Comments", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createCommentDto);
        }

        public async Task<IActionResult> DeleteComment(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7255/api/Comments?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateComment(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7255/api/Comments/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<UpdateCommentDto>(readData);
                return View(jsonData);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            updateCommentDto.Status = true;
            updateCommentDto.CreatedDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var values = JsonConvert.SerializeObject(updateCommentDto);
            var content = new StringContent(values, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7255/api/Comments", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateCommentDto);
        }
    }
}
