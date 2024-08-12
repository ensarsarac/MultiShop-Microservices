using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketService;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly IDiscountService _discountService;

        public ShoppingCartController(IProductService productService, IBasketService basketService, IDiscountService discountService)
        {
            _productService = productService;
            _basketService = basketService;
            _discountService = discountService;
        }

        public async Task<IActionResult> Index(string? code)
        {
            var values =await _basketService.GetBasket();
            ViewBag.totalPrice = values.TotalPrice;
            if(code is null)
            {
                var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10;
                var tax = values.TotalPrice / 100 * 10;
                ViewBag.tax = tax;
                ViewBag.totalPriceWithTax = totalPriceWithTax;
            }
            else
            {
                var codeControl = await _discountService.GetDiscountCode(code);
                if(codeControl.Code is null)
                {
                    ViewBag.NotFoundCoupon = "Böyle bir kupon bulunamadı";
                    var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10;
                    var tax = values.TotalPrice / 100 * 10;
                    ViewBag.tax = tax;
                    ViewBag.totalPriceWithTax = totalPriceWithTax;
                }
                else
                {
                    var tax = values.TotalPrice / 100 * 10;
                    var rate = values.TotalPrice / 100 * codeControl.Rate;
                    var totalPriceWithTax = values.TotalPrice + tax - rate;
                    ViewBag.totalPrice = ViewBag.totalPrice - rate;
                    ViewBag.tax = tax;
                    ViewBag.totalPriceWithTax = totalPriceWithTax;
                    ViewBag.CouponMessage = $"{code} kupon uygulandı";
                }
            }
            
            return View(values);
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductID,
                Price = values.ProductPrice,
                ProductName = values.ProductName,
                Quantity = 1,
                ProductImageUrl=values.ProductImageUrl,
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
