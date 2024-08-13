
namespace MultiShop.WebUI.Services.StatisticServices.CouponStatisticServices
{
    public class CouponStatisticService : ICouponStatisticService
    {
        private readonly HttpClient _httpClient;

        public CouponStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> TotalCouponCount()
        {
            var responseMessage = await _httpClient.GetAsync("discounts/GetDiscountCount");
            var result = await responseMessage.Content.ReadFromJsonAsync<int>();
            return result;
        }
    }
}
