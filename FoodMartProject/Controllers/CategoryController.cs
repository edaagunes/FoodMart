using FoodMartProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IProductService _productService;

		public CategoryController(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> Index(string id)
		{
			var value =await  _productService.GetProductsByCategoryIdAsync(id);
			return View(value);
		}
	}
}
