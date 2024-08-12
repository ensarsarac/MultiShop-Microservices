using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderingServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrdersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrderingService _orderingService;

		public MyOrdersController(IUserService userService, IOrderingService orderingService)
		{
			_userService = userService;
			_orderingService = orderingService;
		}

		public async Task<IActionResult> MyOrderList()
        {
            var user = await _userService.GetUserInfo();

            var values = await _orderingService.GetOrderingByUserId(user.Id);

            return View(values);
        }
    }
}
