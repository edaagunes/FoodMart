using AutoMapper;
using FoodMartProject.Dtos.CategoryDtos;
using FoodMartProject.Dtos.SellingDtos;
using FoodMartProject.Entities;
using FoodMartProject.Settings;
using MongoDB.Driver;

namespace FoodMartProject.Services
{
	public class SellingService : GenericService<Selling, CreateSellingDto, UpdateSellingDto, GetByIdSellingDto, ResultSellingDto>, ISellingService
	{
		public SellingService(IMapper mapper, IDatabaseSettings databaseSettings) : base(mapper, databaseSettings, databaseSettings.SellingCollectionName)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
		}
	}
}
