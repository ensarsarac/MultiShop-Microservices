using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutComponents
{
    public class _AdminLayoutMainSectionComponent:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
