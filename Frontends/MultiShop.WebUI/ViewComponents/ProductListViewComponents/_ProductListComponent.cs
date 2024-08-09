using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponent:ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListComponent(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string? id)
        {
            if (id != null)
            {
                return View(await _productService.GetAllProductByCategoryId(id));
            }
            else
            {
                return View(await _productService.GetAllProductOrderByIdAsync());
            }
            return View();
        }
    }
}
