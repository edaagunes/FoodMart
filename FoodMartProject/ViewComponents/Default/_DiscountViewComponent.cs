using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.ViewComponents.Default
{
	public class _DiscountViewComponents : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
