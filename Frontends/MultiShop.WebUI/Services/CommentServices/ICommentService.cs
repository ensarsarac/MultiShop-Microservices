using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetCommentListByProductId(string id);
        Task CreateComment(CreateCommentDto createCommentDto);
    }
}
