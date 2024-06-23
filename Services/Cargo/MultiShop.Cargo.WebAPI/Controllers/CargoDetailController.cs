using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebAPI.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoDetailController : ControllerBase
	{
		private readonly ICargoDetailService _cargoDetailService;

		public CargoDetailController(ICargoDetailService cargoDetailService)
		{
			_cargoDetailService = cargoDetailService;
		}

		[HttpGet]
		public IActionResult CargoDetailList()
		{
			var values = _cargoDetailService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
		{
			_cargoDetailService.TInsert(new CargoDetail()
			{
				Barcode = createCargoDetailDto.Barcode,
				CargoCompanyId=createCargoDetailDto.CargoCompanyId,
				SenderCustomer = createCargoDetailDto.SenderCustomer,
				ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
			});
			return Ok("Kargo şirketi başarıyla oluşturuldu.");
		}
		[HttpDelete]
		public IActionResult RemoveCargoDetail(int id)
		{
			_cargoDetailService.TDelete(id);
			return Ok("Kargo şirketi başarıyla silindi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetCargoDetailById(int id)
		{
			var value = _cargoDetailService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
		{
			_cargoDetailService.TUpdate(new CargoDetail()
			{
				Barcode = updateCargoDetailDto.Barcode,
				CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
				SenderCustomer = updateCargoDetailDto.SenderCustomer,
				ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
				CargoDetailId=updateCargoDetailDto.CargoDetailId
			});
			return Ok("Kargo şirketi başarıyla güncellendi.");
		}
	}
}
