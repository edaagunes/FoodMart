using FoodMartProject.Dtos.ProductDtos;
using FoodMartProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using X.PagedList.Extensions;

namespace FoodMartProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

		public ProductController(IProductService productService, ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
		}

		public async Task<IActionResult> Index(int page=1,int pageSize=5)
		{
			var products = await _productService.GetAllProductWithCategoryAsync();
			var pagedProducts = products.ToPagedList(page,pageSize);
			return View(pagedProducts);
		}

		[HttpGet]
		public async Task<IActionResult> CreateProduct()
		{
			var categories = await _categoryService.GetAllAsync();
			ViewBag.Categories = categories.Select(c => new SelectListItem
			{
				Value = c.CategoryId.ToString(), 
				Text = c.CategoryName
			}).ToList();
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			await _productService.CreateAsync(createProductDto);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateProduct(string id)
		{
			var product = await _productService.GetByIdAsync(id);
			var categories = await _categoryService.GetAllAsync();
			ViewBag.Categories = categories.Select(c => new SelectListItem
			{
				Value = c.CategoryId.ToString(), 
				Text = c.CategoryName
			}).ToList();
			return View(product);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			await _productService.UpdateAsync(updateProductDto);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> DeleteProduct(string id)
		{
			await _productService.DeleteAsync(id);
			return RedirectToAction("Index");
		}
	}
}
