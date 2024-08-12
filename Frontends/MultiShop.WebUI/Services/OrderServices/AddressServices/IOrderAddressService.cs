using MultiShop.DtoLayer.OrderDtos.AddressesDtos;

namespace MultiShop.WebUI.Services.OrderServices.AddressServices
{
    public interface IOrderAddressService
    {
        //Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task CreateOrderAddressAsync(CreateAddressDto createOrderDto);
        //Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        //Task DeleteAboutAsync(string id);
        //Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
    }
}
