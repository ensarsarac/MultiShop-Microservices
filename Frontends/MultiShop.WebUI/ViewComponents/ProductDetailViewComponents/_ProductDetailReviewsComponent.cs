using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewsComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailReviewsComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7255/api/Comments/CommentListByProductId/"+id);
            var read = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(read);
            return View(values);
        }
    }
}
