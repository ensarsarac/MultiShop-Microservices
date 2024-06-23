using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7250/api/Products/GetProductByIdWithCategory/" + productId);
            var read = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductWithCategoryDto>(read);
            return View(values);
        }
    }
}
