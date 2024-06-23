using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultBrandComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultBrandComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var resMessage = await client.GetAsync("https://localhost:7250/api/Brands");
            var readData = await resMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(readData);
            return View(values);
        }
    }
}
