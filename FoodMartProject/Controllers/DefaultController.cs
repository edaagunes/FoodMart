using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
