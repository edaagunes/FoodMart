using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.ViewComponents.Default
{
	public class _FooterViewComponents : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
