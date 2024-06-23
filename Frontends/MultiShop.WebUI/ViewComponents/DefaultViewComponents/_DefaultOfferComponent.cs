using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultOfferComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOfferComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var resMessage = await client.GetAsync("https://localhost:7250/api/SpecialOffers");
            if(resMessage.IsSuccessStatusCode) {
                var readData = await resMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(readData);
                return View(values);
            }
            return View();
        }
    }
}
