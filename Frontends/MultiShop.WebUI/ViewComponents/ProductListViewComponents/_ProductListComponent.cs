using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductListComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string? id)
        {
            var client = _httpClientFactory.CreateClient();
            if (id != null)
            {
                var resMessage = await client.GetAsync("https://localhost:7250/api/Products/ProductListByCategoryId/" + id);
                if (resMessage.IsSuccessStatusCode)
                {
                    var readData = await resMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(readData);
                    return View(values);
                }
            }
            else
            {
                var resMessage = await client.GetAsync("https://localhost:7250/api/Products/ProductAllListByOrderId");
                if (resMessage.IsSuccessStatusCode)
                {
                    var readData = await resMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(readData);
                    return View(values);
                }
            }
            return View();
        }
    }
}
