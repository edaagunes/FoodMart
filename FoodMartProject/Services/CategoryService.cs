using AutoMapper;
using FoodMartProject.Dtos.CategoryDtos;
using FoodMartProject.Dtos.ProductDtos;
using FoodMartProject.Entities;
using FoodMartProject.Settings;
using MongoDB.Driver;

namespace FoodMartProject.Services
{
	public class CategoryService : GenericService<Category, CreateCategoryDto, UpdateCategoryDto, GetByIdCategoryDto, ResultCategoryDto>, ICategoryService
	{
		public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings) : base(mapper, databaseSettings, databaseSettings.CategoryCollectionName)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
		}

	}
}
