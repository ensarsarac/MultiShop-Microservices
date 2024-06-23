using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AboutController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AboutController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7250/api/Abouts");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<List<ResultAboutDto>>(readData);
				return View(jsonData);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateAbout()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
		{
			var client = _httpClientFactory.CreateClient();
			var values = JsonConvert.SerializeObject(createAboutDto);
			var content = new StringContent(values, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7250/api/Abouts", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View(createAboutDto);
		}

		public async Task<IActionResult> DeleteAbout(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7250/api/Abouts?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateAbout(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7250/api/Abouts/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<UpdateAboutDto>(readData);
				return View(jsonData);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
		{
			var client = _httpClientFactory.CreateClient();
			var values = JsonConvert.SerializeObject(updateAboutDto);
			var content = new StringContent(values, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7250/api/Abouts", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View(updateAboutDto);
		}
	}
}
