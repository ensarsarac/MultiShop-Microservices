using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImagesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImagesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ImagesList(string id)
        {
            TempData["id"] = id;
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7250/api/ProductImages/GetProductImageByProductId/"+id);
            var read=await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(read);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> ImagesList(UpdateProductImageDto updateProductImageDto)
        {
            string id = TempData["id"].ToString();
            var client = _httpClientFactory.CreateClient();
            var read = JsonConvert.SerializeObject(updateProductImageDto);
            var content = new StringContent(read,Encoding.UTF8,"application/json");
            var res = await client.PutAsync("https://localhost:7250/api/ProductImages",content);
            if(res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Product", new {@area="Admin"});
            }
            else
            {
                CreateProductImageDto createProductImageDto= new CreateProductImageDto();
                createProductImageDto.Image1 = updateProductImageDto.Image1;
                createProductImageDto.Image2 = updateProductImageDto.Image2;
                createProductImageDto.Image3 = updateProductImageDto.Image3;
                createProductImageDto.Image4 = updateProductImageDto.Image4;
                createProductImageDto.ProductID = id;
                var read2 = JsonConvert.SerializeObject(createProductImageDto);
                var content2 = new StringContent(read2, Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7250/api/ProductImages", content2);
                return RedirectToAction("Index", "Product", new { @area = "Admin" });
            }
        }
    }
}
