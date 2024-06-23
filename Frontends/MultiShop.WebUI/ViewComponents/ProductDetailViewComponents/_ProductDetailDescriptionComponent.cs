using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDescriptionDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailDescriptionComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailDescriptionComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7250/api/ProductDetails/ProductDetailByProductId/"+productId);
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultProductDetailDto>(read);
                return View(jsonData);
            }
            else
            {
                var result = new ResultProductDetailDto();
                result.ProductDescription = "Bu ürün hakkında henüz açıklama girilmedi";
                result.ProductInfo = "Bu ürün hakkında henüz bilgi girilmedi";
                result.ProductID = productId;
                return View(result);
            }

        }
    }
}
