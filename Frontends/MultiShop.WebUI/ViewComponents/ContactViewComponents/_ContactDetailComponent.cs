using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ContactViewComponents
{
    public class _ContactDetailComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
