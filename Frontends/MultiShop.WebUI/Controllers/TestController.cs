using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultiShop.WebUI.Controllers
{
	public class TestController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ICategoryService _categoryService;

        public TestController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
		{
			//string token = "";
			//var httpClient = new HttpClient();
			//var request = new HttpRequestMessage
			//{
			//	RequestUri = new Uri("http://localhost:5001/connect/token"),
			//	Method = HttpMethod.Post,
			//	Content = new FormUrlEncodedContent(new Dictionary<string, string>
			//	{
			//		{"client_id","MultiShopVisitorId" },
			//		{"client_secret","multishopsecret" },
			//		{"grant_type","client_credentials" },
			//	})
			//};
			//var response = await httpClient.SendAsync(request);
			//if (response.IsSuccessStatusCode)
			//{
			//	var content = await response.Content.ReadAsStringAsync();
			//	var tokenResponse = JObject.Parse(content);
			//	token = tokenResponse["access_token"].ToString();
			//}

			var client = _httpClientFactory.CreateClient();
			//client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
			var responseMessage = await client.GetAsync("http://localhost:7250/api/Categories");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(readData);
				return View(jsonData);
			}
			return View();
		}
		public async Task<IActionResult> Deneme()
		{
			var values = await _categoryService.GetAllCategoryAsync();
			return View(values);
		}
	}
}
