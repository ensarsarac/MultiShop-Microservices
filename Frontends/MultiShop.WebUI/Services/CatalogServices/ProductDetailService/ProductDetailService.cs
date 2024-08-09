using MultiShop.DtoLayer.CatalogDtos.ProductDescriptionDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailService
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultProductDetailDto> GetByIdProductDetailByProductIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("ProductDetails/ProductDetailByProductId/"+id);
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultProductDetailDto>(readData);
            return result;
        }
    }
}
