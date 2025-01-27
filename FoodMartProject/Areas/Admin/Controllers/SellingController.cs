using FoodMartProject.Dtos.SellingDtos;
using FoodMartProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using X.PagedList.Extensions;

namespace FoodMartProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SellingController : Controller
	{
		private readonly ISellingService _sellingService;
		private readonly IProductService _productService;

		public SellingController(ISellingService sellingService, IProductService productService)
		{
			_sellingService = sellingService;
			_productService = productService;
		}

		public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
		{
			var categories = await _sellingService.GetAllSellingWithProductNameAsync();
			var pagedCategories = categories.ToPagedList(page, pageSize);
			return View(pagedCategories);
		}

		[HttpGet]
		public async Task<IActionResult> CreateSelling()
		{
			var products = await _productService.GetAllAsync();
			ViewBag.Products = products.Select(c => new SelectListItem
			{
				Value = c.ProductId.ToString(),
				Text = $"{c.ProductName}|{c.ProductPrice.ToString("F2", CultureInfo.InvariantCulture)}"
			}).ToList();
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateSelling(CreateSellingDto createSellingDto)
		{
			await _sellingService.CreateAsync(createSellingDto);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateSelling(string id)
		{
			var products = await _productService.GetAllAsync();
			ViewBag.Products = products.Select(c => new SelectListItem
			{
				Value = c.ProductId.ToString(),
				Text = $"{c.ProductName}|{c.ProductPrice.ToString("F2", CultureInfo.InvariantCulture)}"
			}).ToList();

			var values = await _sellingService.GetByIdAsync(id);

			// Varsayılan toplam fiyatı hesapla
			var selectedProduct = products.FirstOrDefault(p => p.ProductId == values.ProductId);
			if (selectedProduct != null)
			{
				values.TotalPrice = selectedProduct.ProductPrice * values.Count;
			}

			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateSelling(UpdateSellingDto updateSellingDto)
		{
			await _sellingService.UpdateAsync(updateSellingDto);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> DeleteSelling(string id)
		{
			await _sellingService.DeleteAsync(id);
			return RedirectToAction("Index");
		}
	}
}
