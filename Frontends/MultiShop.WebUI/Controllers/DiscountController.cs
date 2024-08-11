using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketService;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        public async Task<PartialViewResult> ConfirmDiscountCoupon()
        {
            var values =await _basketService.GetBasket();
            return PartialView();
        }
        [HttpPost]
        public IActionResult ConfirmDiscountCoupon(string code)
        {
            var values = _discountService.GetDiscountCode(code);
            return View(values);
        }
    }
}
