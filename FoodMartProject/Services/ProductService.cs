using AutoMapper;
using FoodMartProject.Dtos.ProductDtos;
using FoodMartProject.Dtos.SellingDtos;
using FoodMartProject.Entities;
using FoodMartProject.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;

namespace FoodMartProject.Services
{
	public class ProductService : GenericService<Product, CreateProductDto, UpdateProductDto, GetByIdProductDto, ResultProductDto>, IProductService
	{
		private readonly IMongoCollection<Category> _categoryCollection;
		private readonly ISellingService _sellingService;

		public ProductService(IMapper mapper, IDatabaseSettings databaseSettings, ISellingService sellingService)
			: base(mapper, databaseSettings, databaseSettings.ProductCollectionName)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
			_sellingService = sellingService;
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

		public async Task<List<ResultSellingDto>> GetMostSellingProductsAsync()
		{
			var sellingProducts = await _sellingService.GetMostSellingProductsAsync();

			var result = sellingProducts.Select(selling => new ResultSellingDto
			{
				ProductId = selling.ProductId,
				ProductName = selling.ProductName,
				ProductImage = selling.ProductImage,
				ProductPrice = selling.ProductPrice
			}).ToList();

			return result;
		}

		public async Task<List<ResultProductDto>> GetProductsByCategoryIdAsync(string categoryId)
		{
			// İlk olarak ürünleri kategori id'sine göre al
			var products = await _collection.AsQueryable()
											.Where(product => product.CategoryId == categoryId)
											.ToListAsync();

			// Ürünlerin kategori adlarını ekleyebilmek için kategori verisini al
			var category = await _categoryCollection.AsQueryable()
													 .FirstOrDefaultAsync(c => c.CategoryId == categoryId);

			var result = products.Select(product => new ResultProductDto
			{
				ProductId = product.ProductId,
				ProductName = product.ProductName,
				ProductPrice = product.ProductPrice,
				ProductImage = product.ProductImage,
				CategoryName = category != null ? category.CategoryName : "Kategori Yok"
			}).ToList();
			return result;
		}
	}
}
