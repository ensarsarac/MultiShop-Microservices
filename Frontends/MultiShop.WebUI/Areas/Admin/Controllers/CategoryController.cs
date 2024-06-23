using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7250/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(readData);
                return View(jsonData);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var values = JsonConvert.SerializeObject(createCategoryDto);
            var content = new StringContent(values,Encoding.UTF8,"application/json");   
            var responseMessage = await client.PostAsync("https://localhost:7250/api/Categories",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createCategoryDto);
        }
        
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7250/api/Categories?id="+id);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7250/api/Categories/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<UpdateCategoryDto>(readData);
                return View(jsonData);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var values = JsonConvert.SerializeObject(updateCategoryDto);
            var content = new StringContent(values, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7250/api/Categories",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateCategoryDto);
        }
    }
}
