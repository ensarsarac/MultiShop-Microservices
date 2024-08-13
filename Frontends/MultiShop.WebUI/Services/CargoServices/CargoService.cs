using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;
using MultiShop.WebUI.Services.Interfaces;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CargoServices
{
    public class CargoService : ICargoService
    {
        private readonly HttpClient _httpClient;

        public CargoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("cargocompany", createCargoCompanyDto);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync("cargocompany?id=" + id);
        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync()
        {
            var responseMessage = await _httpClient.GetAsync("cargocompany");
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultCargoCompanyDto>>(readData);
            return result;
        }

        public async Task<GetByIdCargoCompanyDto> GetByIdCargoCompanyAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("cargocompany/" + id);
            var result = await responseMessage.Content.ReadFromJsonAsync<GetByIdCargoCompanyDto>();
            return result;
        }

        public async Task<GetCargoCustomerByUserId> GetCargoCustomerUserId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("cargocustomer/GetByUserId/" + id);
            var result = await responseMessage.Content.ReadFromJsonAsync<GetCargoCustomerByUserId>();
            return result;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("cargocompany", updateCargoCompanyDto);
        }
    }
}
