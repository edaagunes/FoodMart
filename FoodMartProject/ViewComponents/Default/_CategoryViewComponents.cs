using FoodMartProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.ViewComponents.Default
{
	public class _CategoryViewComponents : ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public _CategoryViewComponents(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var categories = await _categoryService.GetAllAsync();
			return View(categories);
		}
	}
}
