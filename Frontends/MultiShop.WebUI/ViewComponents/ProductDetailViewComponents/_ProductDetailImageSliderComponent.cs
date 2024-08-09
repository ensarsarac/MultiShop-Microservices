using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponent:ViewComponent
    {
        private readonly IProductImageService _productImageService;

        public _ProductDetailImageSliderComponent(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
           
            return View(await _productImageService.GetByIdProductImageByProductIdAsync(productId));  
        }
    }
}
