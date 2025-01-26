using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.ViewComponents.Default
{
	public class _SubDiscountViewComponents:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
