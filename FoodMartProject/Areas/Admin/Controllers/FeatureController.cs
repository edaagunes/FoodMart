using FoodMartProject.Dtos.FeatureDtos;
using FoodMartProject.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace FoodMartProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class FeatureController : Controller
	{
		private readonly IFeatureService _featureService;

		public FeatureController(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
		{
			var values = await _featureService.GetAllAsync();
			var pagedFeatures = values.ToPagedList(page, pageSize);
			return View(pagedFeatures);
		}

		[HttpGet]
		public IActionResult CreateFeature()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
		{
			await _featureService.CreateAsync(createFeatureDto);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateFeature(string id)
		{
			var values = await _featureService.GetByIdAsync(id);
			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			await _featureService.UpdateAsync(updateFeatureDto);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> DeleteFeature(string id)
		{
			await _featureService.DeleteAsync(id);
			return RedirectToAction("Index");
		}
	}
}
