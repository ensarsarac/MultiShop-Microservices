using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService _BrandService;

        public BrandController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _BrandService.GetAllBrandAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _BrandService.CreateBrandAsync(createBrandDto);
            return RedirectToAction("Index", "Brand", new { @area = "Admin" });
        }

        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _BrandService.DeleteBrandAsync(id);
            return RedirectToAction("Index", "Brand", new { @area = "Admin" });
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            var values = await _BrandService.GetByIdBrandAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _BrandService.UpdateBrandAsync(updateBrandDto);
            return RedirectToAction("Index", "Brand", new { @area = "Admin" });
        }
    }
}
