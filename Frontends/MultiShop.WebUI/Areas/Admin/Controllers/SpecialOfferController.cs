using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SpecialOfferController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public SpecialOfferController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var resMessage = await client.GetAsync("https://localhost:7250/api/SpecialOffers");
			if (resMessage.IsSuccessStatusCode)
			{
				var readData = await resMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(readData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateSpecialOffer()
		{
			return View();
		}
        [HttpPost]
		public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
		{
			var client = _httpClientFactory.CreateClient();
			var values = JsonConvert.SerializeObject(createSpecialOfferDto);
			var content = new StringContent(values, Encoding.UTF8, "application/json");
			var resMessage = await client.PostAsync("https://localhost:7250/api/SpecialOffers", content);
			if(resMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return View(createSpecialOfferDto);
			}
		}
		
		public async Task<IActionResult> DeleteSpecialOffer(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var resMessage = await client.DeleteAsync("https://localhost:7250/api/SpecialOffers?id="+id);
			if(resMessage.IsSuccessStatusCode )
			{
				return RedirectToAction("Index");
			}
			return View();
		}

        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
			var client = _httpClientFactory.CreateClient();
			var resMessage = await client.GetAsync("https://localhost:7250/api/SpecialOffers/" + id);
			if(resMessage.IsSuccessStatusCode )
			{
				var readData = await resMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(readData);
				return View(values);
			}
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var values = JsonConvert.SerializeObject(updateSpecialOfferDto);
            var content = new StringContent(values, Encoding.UTF8, "application/json");
            var resMessage = await client.PutAsync("https://localhost:7250/api/SpecialOffers", content);
            if (resMessage.IsSuccessStatusCode)
            {
				return RedirectToAction("Index");
            }
            return View();
        }
    }
}
