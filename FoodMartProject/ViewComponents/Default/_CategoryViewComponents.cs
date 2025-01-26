using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.ViewComponents.Default
{
	public class _CategoryViewComponents : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
