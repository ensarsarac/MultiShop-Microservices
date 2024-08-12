using MultiShop.DtoLayer.OrderDtos.OrderingDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.OrderServices.OrderingServices
{
	public class OrderingService : IOrderingService
	{
		private readonly HttpClient _httpClient;

		public OrderingService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<GetOrderingByUserIdDto>> GetOrderingByUserId(string id)
		{
            var responseMessage = await _httpClient.GetAsync("orderings/GetOrderingByUserId/" + id);
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<GetOrderingByUserIdDto>>(readData);
            return result;
        }
	}
}
