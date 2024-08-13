namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public interface ICommentStatisticService
    {
        Task<int> ActiveCommentCount();
        Task<int> PassiveCommentCount();
        Task<int> TotalCommentCount();
    }
}
