using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task DeleteMessageAsync(int id);
        Task<GetByIdMessageDto> GetByIdMessage(int id);
        Task<List<ResultInboxMessageDto>> GetInboxMessage(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessage(string id);
    }
}
