using FoodMartProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartProject.ViewComponents.Default
{
	public class _FeatureViewComponents:ViewComponent
	{
		private readonly IFeatureService _featureService;

		public _FeatureViewComponents(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var features = await _featureService.GetAllAsync();
			return View(features);
		}
	}
}
