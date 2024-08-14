using MultiShop.DtoLayer.MessageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateMessageDto>("messages", createMessageDto);
        }

        public async Task DeleteMessageAsync(int id)
        {
            await _httpClient.DeleteAsync("messages?id=" + id);
        }

        public async Task<GetByIdMessageDto> GetByIdMessage(int id)
        {
            var responseMessage = await _httpClient.GetAsync("messages/GetByIdMessage/" + id);
            var result = await responseMessage.Content.ReadFromJsonAsync<GetByIdMessageDto>();
            return result;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessage(string id)
        {
            var responseMessage = await _httpClient.GetAsync("messages/GetInboxMessageList/" + id);
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultInboxMessageDto>>(readData);
            return result;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessage(string id)
        {
            var responseMessage = await _httpClient.GetAsync("messages/GetSendBoxMessageList/" + id);
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultSendboxMessageDto>>(readData);
            return result;
        }

        public async Task<int> TotalMessageByReceiverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("messages/GetMessageByReceiverId/" + id);
            var readData = await responseMessage.Content.ReadFromJsonAsync<int>();
            return readData;
        }
    }
}
