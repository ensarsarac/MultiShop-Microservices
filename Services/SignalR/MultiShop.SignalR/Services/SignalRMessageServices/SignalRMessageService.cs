namespace MultiShop.SignalR.Services.SignalRMessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        

        public async Task<int> TotalMessageByReceiverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7258/api/MessasgeStatistic");
            var readData = await responseMessage.Content.ReadFromJsonAsync<int>();
            return readData;
        }
    }
}
