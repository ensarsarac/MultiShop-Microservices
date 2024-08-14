
using System.Net.Http;

namespace MultiShop.SignalR.Services.SignalRCommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {

        private readonly HttpClient _httpClient;

        public SignalRCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> TotalCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("comments/TotalCommentCount");
            var result = await responseMessage.Content.ReadFromJsonAsync<int>();
            return result;
        }
    }
}
