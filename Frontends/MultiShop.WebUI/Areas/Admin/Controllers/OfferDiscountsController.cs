﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfferDiscountsController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountsController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscounts", new { @area = "Admin" });
        }

        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction("Index", "OfferDiscounts", new { @area = "Admin" });
        }
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscounts", new { @area = "Admin" });
        }
    }
}
