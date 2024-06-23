using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7250/api/Products/ProductAllListByOrderId");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(readData);
                return View(jsonData);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            await GetCategories();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var values = JsonConvert.SerializeObject(createProductDto);
            var content = new StringContent(values, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7250/api/Products", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createProductDto);
        }
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7250/api/Products?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            await GetCategories();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7250/api/Products/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<UpdateProductDto>(readData);
                return View(jsonData);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var values = JsonConvert.SerializeObject(updateProductDto);
            var content = new StringContent(values, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7250/api/Products", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateProductDto);
        }

        public async Task GetCategories()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7250/api/Categories");
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(readData);
            ViewBag.categories = new SelectList(jsonData, "CategoryID", "CategoryName");
        }

    }
}
