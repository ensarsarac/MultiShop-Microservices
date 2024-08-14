namespace MultiShop.SignalR.Services.SignalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> TotalMessageByReceiverId(string id);
    }
}
