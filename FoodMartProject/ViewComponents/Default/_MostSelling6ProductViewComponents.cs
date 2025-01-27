using FoodMartProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.ViewComponents.Default
{
	public class _MostSelling6ProductViewComponents:ViewComponent
	{
		private readonly IProductService _productService;

		public _MostSelling6ProductViewComponents(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var mostSellingProducts = await _productService.GetMostSellingProductsAsync();
			return View(mostSellingProducts);
		}
	}
}
