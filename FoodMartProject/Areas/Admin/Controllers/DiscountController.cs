using FoodMartProject.Dtos.DiscountDtos;
using FoodMartProject.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace FoodMartProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DiscountController : Controller
	{
		private readonly IDiscountService _discountService;

		public DiscountController(IDiscountService discountService)
		{
			_discountService = discountService;
		}

		public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
		{
			var categories = await _discountService.GetAllAsync();
			var pagedCategories = categories.ToPagedList(page, pageSize);
			return View(pagedCategories);
		}

		[HttpGet]
		public IActionResult CreateDiscount()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
		{
			await _discountService.CreateAsync(createDiscountDto);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateDiscount(string id)
		{
			var values = await _discountService.GetByIdAsync(id);
			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
		{
			await _discountService.UpdateAsync(updateDiscountDto);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> DeleteDiscount(string id)
		{
			await _discountService.DeleteAsync(id);
			return RedirectToAction("Index");
		}
	}
}
