using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailsService _ProductDetailService;

        public ProductDetailsController(IProductDetailsService ProductDetailService)
        {
            _ProductDetailService = ProductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _ProductDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }
		[HttpGet("ProductDetailByProductId/{id}")]
		public async Task<IActionResult> ProductDetailByProductId(string id)
		{
			var values = await _ProductDetailService.GetByIdProductDetailByProductIdAsync(id);
			return Ok(values);
		}
		[HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var values = await _ProductDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _ProductDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _ProductDetailService.DeleteProductDetailAsync(id);
            return Ok("Kayıt başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _ProductDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Kayıt başarıyla güncellendi");
        }
    }
}
