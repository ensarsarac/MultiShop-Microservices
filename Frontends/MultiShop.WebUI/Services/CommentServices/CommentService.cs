using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateComment(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCommentDto>("comments", createCommentDto);
        }

        public async Task<List<ResultCommentDto>> GetCommentListByProductId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("comments/CommentListByProductId/"+id);
            var readData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultCommentDto>>(readData);
            return result;
        }
    }
}
