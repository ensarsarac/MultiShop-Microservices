using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebAPI.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoCustomerController : ControllerBase
	{
		private readonly ICargoCustomerService _cargoCustomerService;

		public CargoCustomerController(ICargoCustomerService cargoCustomerService)
		{
			_cargoCustomerService = cargoCustomerService;
		}

		[HttpGet]
		public IActionResult CargoCustomerList()
		{
			var values = _cargoCustomerService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
		{
			_cargoCustomerService.TInsert(new CargoCustomer()
			{
				Address = createCargoCustomerDto.Address,
				City = createCargoCustomerDto.City,
				District = createCargoCustomerDto.District,
				Email = createCargoCustomerDto.Email,
				Name = createCargoCustomerDto.Name,
				PhoneNumber = createCargoCustomerDto.PhoneNumber,
				Surname = createCargoCustomerDto.Surname,
				UserCustomerId = createCargoCustomerDto.UserCustomerId,
			});
			return Ok("Kargo şirketi başarıyla oluşturuldu.");
		}
		[HttpDelete]
		public IActionResult RemoveCargoCustomer(int id)
		{
			_cargoCustomerService.TDelete(id);
			return Ok("Kargo şirketi başarıyla silindi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetCargoCustomerById(int id)
		{
			var value = _cargoCustomerService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
		{
			_cargoCustomerService.TUpdate(new CargoCustomer()
			{
				Address = updateCargoCustomerDto.Address,
				City = updateCargoCustomerDto.City,
				District = updateCargoCustomerDto.District,
				Email = updateCargoCustomerDto.Email,
				Name = updateCargoCustomerDto.Name,
				PhoneNumber = updateCargoCustomerDto.PhoneNumber,
				Surname = updateCargoCustomerDto.Surname,
				CargoCustomerId=updateCargoCustomerDto.CargoCustomerId,
			});
			return Ok("Kargo şirketi başarıyla güncellendi.");
		}

        [HttpGet("GetByUserId/{id}")]
        public async Task<IActionResult> GetByUserId(string id)
        {
            var value =await _cargoCustomerService.TGetCargoCustomerByUserId(id);
            return Ok(value);
        }
    }
}
