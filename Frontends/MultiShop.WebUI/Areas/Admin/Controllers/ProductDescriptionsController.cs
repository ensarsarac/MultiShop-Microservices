using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDescriptionDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductDescriptionsController : Controller
	{
		
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductDescriptionsController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index(string id)
		{
			TempData["id"] = id;
			var client = _httpClientFactory.CreateClient();
			var res = await client.GetAsync("https://localhost:7250/api/ProductDetails/ProductDetailByProductId/" + id);
			var read = await res.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(read);
			return View(values);
		}
		[HttpPost]
        public async Task<IActionResult> Index(UpdateProductDetailDto updateProductDetailDto)
        {
			string id = TempData["id"].ToString();
            var client = _httpClientFactory.CreateClient();
            var read = JsonConvert.SerializeObject(updateProductDetailDto);
            var content = new StringContent(read, Encoding.UTF8, "application/json");
            var res = await client.PutAsync("https://localhost:7250/api/ProductDetails", content);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { @area = "Admin" });
			}
			else
			{
				CreateProductDetailDto createProductDetailDto = new CreateProductDetailDto();
				createProductDetailDto.ProductInfo = updateProductDetailDto.ProductInfo;
				createProductDetailDto.ProductDescription= updateProductDetailDto.ProductDescription;
				createProductDetailDto.ProductID = id;
                var read2 = JsonConvert.SerializeObject(createProductDetailDto);
                var content2 = new StringContent(read2, Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7250/api/ProductDetails", content2);
                return RedirectToAction("Index", "Product", new { @area = "Admin" });
            }
        }
    }
}
