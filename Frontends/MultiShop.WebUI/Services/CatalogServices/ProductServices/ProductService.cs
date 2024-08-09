using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("products", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync("products?id=" + id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products");
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultProductDto>>(readData);
            return result;
        }

        public async Task<List<ResultProductDto>> GetAllProductByCategoryId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("products/ProductListByCategoryId/"+id);
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultProductDto>>(readData);
            return result;
        }

        public async Task<List<ResultProductDto>> GetAllProductOrderByIdAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products/ProductAllListByOrderId");
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultProductDto>>(readData);
            return result;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products/ProductListWithCategory");
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(readData);
            return result;
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("products/" + id);
            var result = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDto>();
            return result;
        }

        public async Task<ResultProductWithCategoryDto> GetByIdProductWithCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("products/GetProductByIdWithCategory/"+id);
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultProductWithCategoryDto>(readData);
            return result;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDto>("products", updateProductDto);
        }
    }
}
