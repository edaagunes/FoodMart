using AutoMapper;
using FoodMartProject.Dtos.CategoryDtos;
using FoodMartProject.Dtos.ProductDtos;
using FoodMartProject.Dtos.SellingDtos;
using FoodMartProject.Entities;
using FoodMartProject.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;

namespace FoodMartProject.Services
{
	public class SellingService : GenericService<Selling, CreateSellingDto, UpdateSellingDto, GetByIdSellingDto, ResultSellingDto>, ISellingService
	{
		private readonly IMongoCollection<Product> _productCollection;
		public SellingService(IMapper mapper, IDatabaseSettings databaseSettings) : base(mapper, databaseSettings, databaseSettings.SellingCollectionName)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
		}

		public async Task<List<ResultSellingDto>> GetAllSellingWithProductNameAsync()
		{
			// Ürünleri ve satışları birleştir
			var query = await _collection.AsQueryable()
				.Join(
					_productCollection.AsQueryable(),
					product => product.ProductId,
					selling => selling.ProductId,
					(selling, product) => new ResultSellingDto
					{
						ProductId = product.ProductId,
						Count = selling.Count,
						SellingDate = selling.SellingDate,
						SellingId = selling.SellingId,
						TotalPrice = selling.TotalPrice,
						ProductName = product.ProductName
					}
				).ToListAsync();

			return query;
		}

		public async Task<List<ResultSellingDto>> GetMostSellingProductsAsync()
		{
			// En çok satılan ürünleri hesapla
			var topSellingProducts = await _collection.Aggregate()
				.Group(x => x.ProductId, g => new
				{
					ProductId = g.Key,
					TotalCount = g.Sum(x => x.Count)
				})
				.SortByDescending(x => x.TotalCount)
				.Limit(6)
				.ToListAsync();

			// Ürünlerin detaylarını almak için ProductService 
			var productIds = topSellingProducts.Select(x => x.ProductId).ToList();
			var products = await _productCollection.AsQueryable()
				.Where(product => productIds.Contains(product.ProductId))
				.ToListAsync();

			// Sonuçları oluşturun
			var result = topSellingProducts.Select(topProduct => new ResultSellingDto
			{
				ProductId = topProduct.ProductId,
				Count = topProduct.TotalCount,
				ProductName = products.FirstOrDefault(product => product.ProductId == topProduct.ProductId)?.ProductName,
				ProductImage = products.FirstOrDefault(product => product.ProductId == topProduct.ProductId)?.ProductImage,
				ProductPrice = (decimal)(products.FirstOrDefault(product => product.ProductId == topProduct.ProductId)?.ProductPrice)
			}).ToList();

			return result;
		}
	}
}
