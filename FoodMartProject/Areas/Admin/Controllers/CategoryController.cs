using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.Areas.Admin.Controllers
{
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
