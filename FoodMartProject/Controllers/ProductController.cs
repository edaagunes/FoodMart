using FoodMartProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> Index()
		{
			var values=await _productService.GetAllAsync();
			return View(values);
		}
	}
}
