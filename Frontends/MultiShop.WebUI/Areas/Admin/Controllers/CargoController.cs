using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CargoController : Controller
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        public async Task<IActionResult> CargoList()
        {
            var values = await _cargoService.GetAllCargoCompanyAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("CargoList", "Cargo", new { @area = "Admin" });
        }
        public IActionResult CreateCargoCompany()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoService.CreateCargoCompanyAsync(createCargoCompanyDto);
            return RedirectToAction("CargoList", "Cargo", new { @area = "Admin" });
        }
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            var values = await _cargoService.GetByIdCargoCompanyAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
            return RedirectToAction("CargoList", "Cargo", new { @area = "Admin" });
        }
    }
}
