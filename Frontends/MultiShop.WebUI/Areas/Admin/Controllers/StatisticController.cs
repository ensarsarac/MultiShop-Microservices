using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.StatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CouponStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticService;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _statisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly ICouponStatisticService _couponStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;

        public StatisticController(ICatalogStatisticService statisticService, IUserStatisticService userStatisticService, ICommentStatisticService commentStatisticService, ICouponStatisticService couponStatisticService, IMessageStatisticService messageStatisticService)
        {
            _statisticService = statisticService;
            _userStatisticService = userStatisticService;
            _commentStatisticService = commentStatisticService;
            _couponStatisticService = couponStatisticService;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.brandCount = await _statisticService.BrandCount();

            ViewBag.productCount = await _statisticService.ProductCount();

            ViewBag.categoryCount = await _statisticService.CategoryCount();

            ViewBag.productMaxPriceProductName = await _statisticService.GetMaxProductName();

            ViewBag.productMinPriceProductName = await _statisticService.GetMinProductName();

            ViewBag.userCount = await _userStatisticService.GetUserCount();

            ViewBag.activeComment = await _commentStatisticService.ActiveCommentCount();

            ViewBag.passiveComment = await _commentStatisticService.PassiveCommentCount();

            ViewBag.totalComment = await _commentStatisticService.TotalCommentCount();

            ViewBag.couponCount = await _couponStatisticService.TotalCouponCount();

            ViewBag.messageCount = await _messageStatisticService.TotalMessageCount();

            return View();
        }
    }
}
