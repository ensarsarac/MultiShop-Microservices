using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailImageSliderComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7250/api/ProductImages/GetProductImageByProductId/" + productId);
            var read = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductImageDto>(read);
            return View(values);  
        }
    }
}
