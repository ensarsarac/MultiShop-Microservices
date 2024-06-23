using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultFeatureComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultFeatureComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var resMessage = await client.GetAsync("https://localhost:7250/api/Features");
            var readData = await resMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(readData);
            return View(values);
        }
    }
}
