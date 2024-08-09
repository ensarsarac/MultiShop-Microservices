﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultiShop.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _UILayoutFooterComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values =await _aboutService.GetAllAboutAsync();
            return View(values);
        }
    }
}
