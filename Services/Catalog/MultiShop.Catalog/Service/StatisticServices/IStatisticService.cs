namespace MultiShop.Catalog.Service.StatisticServices
{
    public interface IStatisticService
    {
        Task<int> CategoryCount();
        Task<int> ProductCount();
        Task<int> BrandCount();
        Task<decimal> ProductAvgPrice();

        Task<string> GetMaxProductName();
        Task<string> GetMinProductName();
    }
}
