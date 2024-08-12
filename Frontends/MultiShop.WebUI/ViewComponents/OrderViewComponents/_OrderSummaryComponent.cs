using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketService;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponent:ViewComponent
    {
        private readonly IBasketService _basketService;

        public _OrderSummaryComponent(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var basketTotal = await _basketService.GetBasket();

            var basketItem = basketTotal.BasketItems;

            return View(basketItem);
        }
    }
}
