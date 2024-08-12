using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<GetByIdMessageDto> GetByIdMessage(int id);
        Task<List<ResultInboxMessageDto>> GetInboxMessage(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessage(string id);
    }
}
