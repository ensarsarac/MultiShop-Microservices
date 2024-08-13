
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> BrandCount()
        {
            var responseMessage = await _httpClient.GetAsync("Statistic/GetBrandCount");
            var result = await responseMessage.Content.ReadFromJsonAsync<int>();
            return result;
        }

        public async Task<int> CategoryCount()
        {
            var responseMessage = await _httpClient.GetAsync("Statistic/GetCategoryCount");
            var result = await responseMessage.Content.ReadFromJsonAsync<int>();
            return result;
        }

        public async Task<string> GetMaxProductName()
        {

            var responseMessage = await _httpClient.GetAsync("Statistic/GetMaxPriceProductName");
            var result = await responseMessage.Content.ReadAsStringAsync();
            return result;

        }

        public async Task<string> GetMinProductName()
        {
            var responseMessage = await _httpClient.GetAsync("Statistic/GetMinPriceProductName");
            var result = await responseMessage.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<decimal> ProductAvgPrice()
        {
            var responseMessage = await _httpClient.GetAsync("Statistic/GetProductAvgPrice");
            var result = await responseMessage.Content.ReadFromJsonAsync<decimal>();
            return result;
        }

        public async Task<int> ProductCount()
        {
            var responseMessage = await _httpClient.GetAsync("Statistic/GetProductCount");
            var result = await responseMessage.Content.ReadFromJsonAsync<int>();
            return result;
        }
    }
}
