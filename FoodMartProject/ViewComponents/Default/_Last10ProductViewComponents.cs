using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.ViewComponents.Default
{
	public class _Last10ProductViewComponents : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
