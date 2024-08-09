using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultOfferDiscountComponent:ViewComponent
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public _DefaultOfferDiscountComponent(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View(await _offerDiscountService.GetAllOfferDiscountAsync());
        }
    }
}
