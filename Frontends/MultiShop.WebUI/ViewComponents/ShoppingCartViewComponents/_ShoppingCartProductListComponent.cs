using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketService;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartProductListComponent:ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ShoppingCartProductListComponent(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasket();
            return View(basketTotal.BasketItems);
        }
    }
}
