using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.AddressesDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.AddressServices;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _addressService;
        private readonly IUserService _userService;

        public OrderController(IOrderAddressService addressService, IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAddressDto createAddressDto)
        {

            var userInfo = await _userService.GetUserInfo();

            createAddressDto.UserId = userInfo.Id;
            createAddressDto.Description = "açıklama";

            await _addressService.CreateOrderAddressAsync(createAddressDto);

            return RedirectToAction("Index","Payment");
        }
    }
}
