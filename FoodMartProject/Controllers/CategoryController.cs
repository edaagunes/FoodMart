using FoodMartProject.Entities;
using FoodMartProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Category category)
		{
			_categoryService.AddCategoryAsync(category);
			return RedirectToAction("Index");
		}
	}
}
