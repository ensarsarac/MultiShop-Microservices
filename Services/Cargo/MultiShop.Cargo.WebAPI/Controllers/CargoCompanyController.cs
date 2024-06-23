using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebAPI.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoCompanyController : ControllerBase
	{
		private readonly ICargoCompanyService _cargoCompanyService;

		public CargoCompanyController(ICargoCompanyService cargoCompanyService)
		{
			_cargoCompanyService = cargoCompanyService;
		}

		[HttpGet]
		public IActionResult CargoCompanyList()
		{
			var values = _cargoCompanyService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
		{
			_cargoCompanyService.TInsert(new CargoCompany()
			{
				CargoCompanyName = createCargoCompanyDto.CargoCompanyName,
			});
			return Ok("Kargo şirketi başarıyla oluşturuldu.");
		}
		[HttpDelete]
		public IActionResult RemoveCargoCompany(int id)
		{
			_cargoCompanyService.TDelete(id);
			return Ok("Kargo şirketi başarıyla silindi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetCargoCompanyById(int id)
		{
			var value = _cargoCompanyService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
		{
			_cargoCompanyService.TUpdate(new CargoCompany()
			{
				CargoCompanyId=updateCargoCompanyDto.CargoCompanyId,
				CargoCompanyName=updateCargoCompanyDto.CargoCompanyName
			});
			return Ok("Kargo şirketi başarıyla güncellendi.");
		}
	}
}
