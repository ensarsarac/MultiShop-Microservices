using MultiShop.Catalog.Dtos.ProductDetailsDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailsService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailByProductIdAsync(string id);
    }
}
