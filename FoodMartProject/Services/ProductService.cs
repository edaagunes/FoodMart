using AutoMapper;
using FoodMartProject.Dtos.ProductDtos;
using FoodMartProject.Entities;
using FoodMartProject.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FoodMartProject.Services
{
	public class ProductService : GenericService<Product, CreateProductDto, UpdateProductDto, GetByIdProductDto, ResultProductDto>, IProductService
	{
		private readonly IMongoCollection<Category> _categoryCollection;

		public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
			: base(mapper, databaseSettings, databaseSettings.ProductCollectionName)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
		}

		public async Task<List<ResultProductDto>> GetAllProductWithCategoryAsync()
		{
			// Ürünleri ve kategorileri birleştir
			var query = await _collection.AsQueryable()
				.Join(
					_categoryCollection.AsQueryable(),
					product => product.CategoryId,
					category => category.CategoryId,
					(product, category) => new ResultProductDto
					{
						ProductId = product.ProductId,
						ProductName = product.ProductName,
						ProductStock = product.ProductStock,
						ProductPrice = product.ProductPrice,
						ProductImage = product.ProductImage,
						CategoryId = category.CategoryId,
						CategoryName = category.CategoryName
					}
				).ToListAsync();

			return query;
		}
	}
}
