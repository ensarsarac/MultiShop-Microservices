using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeaturesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeaturesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7250/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(readData);
                return View(jsonData);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var values = JsonConvert.SerializeObject(createFeatureDto);
            var content = new StringContent(values, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7250/api/Features", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createFeatureDto);
        }

        public async Task<IActionResult> DeleteFeature(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7250/api/Features?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7250/api/Features/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<UpdateFeatureDto>(readData);
                return View(jsonData);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var values = JsonConvert.SerializeObject(updateFeatureDto);
            var content = new StringContent(values, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7250/api/Features", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateFeatureDto);
        }
    }
}
