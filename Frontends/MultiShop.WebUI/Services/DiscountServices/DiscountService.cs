using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            var response = await _httpClient.GetAsync("discounts/GetCodeDetailByCode/" + code);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
                return result;
            }
            else
            {
                return new GetDiscountCodeDetailByCode
                {
                    Code = null,
                    IsActive = false,
                    Rate = 0,
                    ValidDate = DateTime.Now,
                };
            }


        }
    }
}
