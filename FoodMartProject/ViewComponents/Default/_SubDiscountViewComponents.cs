using FoodMartProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.ViewComponents.Default
{
	public class _SubDiscountViewComponents:ViewComponent
	{
		private readonly IDiscountService _discountService;

		public _SubDiscountViewComponents(IDiscountService discountService)
		{
			_discountService = discountService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values=await _discountService.GetAllAsync();
			return View(values);
		}
	}
}
