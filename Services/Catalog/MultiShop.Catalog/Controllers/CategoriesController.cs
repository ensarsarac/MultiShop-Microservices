using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpGet("GetCategoryListWithProductCount")]
        public async Task<IActionResult> GetCategoryListWithProductCount()
        {
            var values = await _categoryService.GetCategoryWithProductCount();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var values = await _categoryService.GetByIdCategoryAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kayıt başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kayıt başarıyla güncellendi");
        }
    }
}
