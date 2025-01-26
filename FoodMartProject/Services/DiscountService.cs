using AutoMapper;
using FoodMartProject.Dtos.CategoryDtos;
using FoodMartProject.Dtos.DiscountDtos;
using FoodMartProject.Entities;
using FoodMartProject.Settings;
using MongoDB.Driver;

namespace FoodMartProject.Services
{
	public class DiscountService : GenericService<Discount, CreateDiscountDto, UpdateDiscountDto, GetByIdDiscountDto, ResultDiscountDto>, IDiscountService
	{
		public DiscountService(IMapper mapper, IDatabaseSettings databaseSettings) :base(mapper, databaseSettings, databaseSettings.DiscountCollectionName)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
		}
	}
}
