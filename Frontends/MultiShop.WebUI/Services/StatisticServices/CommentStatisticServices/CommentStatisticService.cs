
namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> ActiveCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("comments/ActiveCommentCount");
            var result = await responseMessage.Content.ReadFromJsonAsync<int>();
            return result;
        }

        public async Task<int> PassiveCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("comments/PassiveCommentCount");
            var result = await responseMessage.Content.ReadFromJsonAsync<int>();
            return result;
        }

        public async Task<int> TotalCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("comments/TotalCommentCount");
            var result = await responseMessage.Content.ReadFromJsonAsync<int>();
            return result;
        }
    }
}
