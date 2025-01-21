using FoodMartProject.Dtos.CategoryDtos;
using FoodMartProject.Dtos.ProductDtos;
using FoodMartProject.Entities;

namespace FoodMartProject.Services
{
	public interface ICategoryService
	{
		Task<List<ResultCategoryDto>> GetAllCategory();
		Task AddCategoryAsync(Category category);
	}
}
