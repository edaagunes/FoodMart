using AutoMapper;
using FoodMartProject.Dtos.CategoryDtos;
using FoodMartProject.Dtos.ProductDtos;
using FoodMartProject.Entities;
using FoodMartProject.Settings;
using MongoDB.Driver;

namespace FoodMartProject.Services
{
	public class CategoryService : BaseMongoService<Category>,ICategoryService
	{
		private readonly IMapper _mapper;

		public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
			: base(databaseSettings, databaseSettings.CategoryCollectionName)
		{
			_mapper = mapper;
		}

		public async Task<List<ResultCategoryDto>> GetAllCategory()
		{
			var values = await _collection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultCategoryDto>>(values);
		}
		public async Task AddCategoryAsync(Category category)
		{
			await _collection.InsertOneAsync(category);
		}
	}
}
