using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Service.FeatureSliderServices;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSlidersController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetFeatureSliderList()
        {
            return Ok(await _featureSliderService.GetAllFeatureSliderAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFeatureSlider(string id)
        {
            return Ok(await _featureSliderService.GetByIdFeatureSliderAsync(id));
        }
        [HttpGet("ChangeStatusToFalse/{id}")]
        public async Task<IActionResult> ChangeStatusToFalse(string id)
        {
            await _featureSliderService.FeatureSliderChangeStatusToFalse(id);
            return Ok("Durum pasif oldu");
        }
        [HttpGet("ChangeStatusToTrue/{id}")]
        public async Task<IActionResult> ChangeStatusToTrue(string id)
        {
            await _featureSliderService.FeatureSliderChangeStatusToTrue(id);
            return Ok("Durum aktif oldu");
        }
        [HttpPost]
        public async Task<IActionResult> CerateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok("Kayıt başarıyla eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Kayıt başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("Kayıt başarıyla silindi.");
        }
    }
}
