using MultiShop.DtoLayer.CatalogDtos.ProductDescriptionDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailService
{
    public interface IProductDetailService
    {
        Task<ResultProductDetailDto> GetByIdProductDetailByProductIdAsync(string id);
    }
}
