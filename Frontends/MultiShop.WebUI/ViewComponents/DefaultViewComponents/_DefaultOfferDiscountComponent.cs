using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultOfferDiscountComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOfferDiscountComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var resMessage = await client.GetAsync("https://localhost:7250/api/OfferDiscounts");
            var readData = await resMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(readData);
            return View(values);
        }
    }
}
