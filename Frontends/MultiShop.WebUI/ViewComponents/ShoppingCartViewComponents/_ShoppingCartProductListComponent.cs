using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartProductListComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
