namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticService
{
    public interface IMessageStatisticService
    {
        Task<int> TotalMessageCount();
    }
}
