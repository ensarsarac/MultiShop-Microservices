using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CargoServices;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.UserIdentityServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly ICargoService _cargoService;

        public UserController(IUserIdentityService userIdentityService, ICargoService cargoService)
        {
            _userIdentityService = userIdentityService;
            _cargoService = cargoService;
        }

        public async Task<IActionResult> UserList()
        {
            var values = await _userIdentityService.GetAllUserAsync();
            return View(values);
        }

        public async Task<IActionResult> UserAddressInfo(string id)
        {
            var values = await _cargoService.GetCargoCustomerUserId(id);
            return View(values);
        }
    }
}
