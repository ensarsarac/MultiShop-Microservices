using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResultProductImageDto> GetByIdProductImageByProductIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("ProductImages/GetProductImageByProductId/" + id);
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultProductImageDto>(readData);
            return result;
        }
    }
}
