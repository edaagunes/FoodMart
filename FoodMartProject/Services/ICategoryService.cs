using FoodMartProject.Dtos.CategoryDtos;
using FoodMartProject.Dtos.ProductDtos;
using FoodMartProject.Entities;

namespace FoodMartProject.Services
{
	public interface ICategoryService:IGenericService<Category, CreateCategoryDto, UpdateCategoryDto, GetByIdCategoryDto, ResultCategoryDto>
	{

	}
}
