﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutComponents
{
    public class _AdminLayoutSideBarComponent:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
