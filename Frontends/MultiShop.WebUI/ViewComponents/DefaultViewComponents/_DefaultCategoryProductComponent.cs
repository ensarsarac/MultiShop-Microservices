using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCategoryProductComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultCategoryProductComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var resMessage = await client.GetAsync("https://localhost:7250/api/Categories/GetCategoryListWithProductCount");
            var readData = await resMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryWithProductCountDto>>(readData);
            return View(values);
        }
    }
}
