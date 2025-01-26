using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.ViewComponents.Default
{
	public class _NavbarLayout:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
