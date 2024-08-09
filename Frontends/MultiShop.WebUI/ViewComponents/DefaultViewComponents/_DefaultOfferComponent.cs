using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultOfferComponent:ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

        public _DefaultOfferComponent(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View(await _specialOfferService.GetAllSpecialOfferAsync());
        }
    }
}
