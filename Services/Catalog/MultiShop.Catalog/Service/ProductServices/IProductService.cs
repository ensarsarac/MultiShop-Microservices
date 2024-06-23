using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<ResultProductWithCategoryDto> GetByIdProductWithCategoryAsync(string id);

        Task<List<ResultProductDto>> GetAllProductOrderByIdAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllListProductOrderByIdAsync();
        Task<List<ResultProductDto>> GetAllProductByCategoryId(string id);
    }
}
