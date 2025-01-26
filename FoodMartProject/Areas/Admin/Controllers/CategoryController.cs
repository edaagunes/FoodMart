using FoodMartProject.Dtos.CategoryDtos;
using FoodMartProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList.Extensions;

namespace FoodMartProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
		{
			var categories = await _categoryService.GetAllAsync();
			var pagedCategories = categories.ToPagedList(page, pageSize);
			return View(pagedCategories);
		}

		[HttpGet]
		public IActionResult CreateCategory()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
			await _categoryService.CreateAsync(createCategoryDto);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateCategory(string id)
		{
			var values = await _categoryService.GetByIdAsync(id);
			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			await _categoryService.UpdateAsync(updateCategoryDto);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> DeleteCategory(string id)
		{
			await _categoryService.DeleteAsync(id);
			return RedirectToAction("Index");
		}
	}
}
