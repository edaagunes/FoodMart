using FoodMartProject.Dtos.ProductDtos;
using FoodMartProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> Index()
		{
			var products = await _productService.GetAllProductWithCategoryAsync();
			return View(products);
		}

		[HttpGet]
		public IActionResult CreateProduct()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			await _productService.CreateAsync(createProductDto);
			return RedirectToAction("Index");
		}
	}
}
