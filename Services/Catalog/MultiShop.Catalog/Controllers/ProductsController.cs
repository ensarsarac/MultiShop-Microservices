using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("ProductListByCategoryId/{id}")]
        public async Task<IActionResult> ProductListByCategoryId(string id)
        {
            var values = await _productService.GetAllProductByCategoryId(id);
            return Ok(values);
        }
        [HttpGet("ProductAllListByOrderId")]
        public async Task<IActionResult> ProductAllListByOrderId()
        {
            var values = await _productService.GetAllListProductOrderByIdAsync();
            return Ok(values);
        }
        [HttpGet("ProductListByOrderId")]
        public async Task<IActionResult> ProductListByOrderId()
        {
            var values = await _productService.GetAllProductOrderByIdAsync();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productService.GetAllProductWithCategoryAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            return Ok(values);
        }
        [HttpGet("GetProductByIdWithCategory/{id}")]
        public async Task<IActionResult> GetProductByIdWithCategory(string id)
        {
            var values = await _productService.GetByIdProductWithCategoryAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Ürün başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Ürün başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün başarıyla güncellendi");
        }
    }
}
