namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public interface ICatalogStatisticService
    {
        Task<int> CategoryCount();
        Task<int> ProductCount();
        Task<int> BrandCount();
        Task<decimal> ProductAvgPrice();
        Task<string> GetMaxProductName();
        Task<string> GetMinProductName();
    }
}
