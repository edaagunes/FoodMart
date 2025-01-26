using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.ViewComponents.Default
{
	public class _SearchCanvasLayout:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
