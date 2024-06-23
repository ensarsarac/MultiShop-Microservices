using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebAPI.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoOperationController : ControllerBase
	{
		private readonly ICargoOperationsService _cargoOperationService;

		public CargoOperationController(ICargoOperationsService cargoOperationService)
		{
			_cargoOperationService = cargoOperationService;
		}

		[HttpGet]
		public IActionResult CargoOperationList()
		{
			var values = _cargoOperationService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
		{
			_cargoOperationService.TInsert(new CargoOperation()
			{
				Barcode = createCargoOperationDto.Barcode,
				Description = createCargoOperationDto.Description,
				OperationDate = createCargoOperationDto.OperationDate,
			});
			return Ok("Kargo şirketi başarıyla oluşturuldu.");
		}
		[HttpDelete]
		public IActionResult RemoveCargoOperation(int id)
		{
			_cargoOperationService.TDelete(id);
			return Ok("Kargo şirketi başarıyla silindi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetCargoOperationById(int id)
		{
			var value = _cargoOperationService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
		{
			_cargoOperationService.TUpdate(new CargoOperation()
			{
				Barcode = updateCargoOperationDto.Barcode,
				Description = updateCargoOperationDto.Description,
				OperationDate = updateCargoOperationDto.OperationDate,
				CargoOperationId=updateCargoOperationDto.CargoOperationId,
			});
			return Ok("Kargo şirketi başarıyla güncellendi.");
		}
	}
}
