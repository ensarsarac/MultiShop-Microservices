using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7250/api/Brands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultBrandDto>>(readData);
                return View(jsonData);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var values = JsonConvert.SerializeObject(createBrandDto);
            var content = new StringContent(values, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7250/api/Brands", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createBrandDto);
        }

        public async Task<IActionResult> DeleteBrand(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7250/api/Brands?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7250/api/Brands/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<UpdateBrandDto>(readData);
                return View(jsonData);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var values = JsonConvert.SerializeObject(updateBrandDto);
            var content = new StringContent(values, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7250/api/Brands", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateBrandDto);
        }
    }
}
