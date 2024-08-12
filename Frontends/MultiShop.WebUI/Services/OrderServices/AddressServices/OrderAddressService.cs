using MultiShop.DtoLayer.OrderDtos.AddressesDtos;

namespace MultiShop.WebUI.Services.OrderServices.AddressServices
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly HttpClient _httpClient;

        public OrderAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOrderAddressAsync(CreateAddressDto createOrderDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAddressDto>("Addresses", createOrderDto);
        }
    }
}
