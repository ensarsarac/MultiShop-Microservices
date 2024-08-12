using MultiShop.DtoLayer.OrderDtos.OrderingDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderingServices
{
	public interface IOrderingService
	{
		Task<List<GetOrderingByUserIdDto>> GetOrderingByUserId(string id);
	}
}
