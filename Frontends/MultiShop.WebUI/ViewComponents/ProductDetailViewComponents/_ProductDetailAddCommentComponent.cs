using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailAddCommentComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new CreateCommentDto());
        }
    }
}
