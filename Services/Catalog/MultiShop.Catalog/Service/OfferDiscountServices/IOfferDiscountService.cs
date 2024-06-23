using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Service.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
        Task UpdateOfferDiscountAsync(UpdateOffderDiscountDto updateOffderDiscountDto);
        Task DeleteOfferDiscountAsync(string id);
        Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
    }
}
