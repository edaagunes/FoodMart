using AutoMapper;
using FoodMartProject.Dtos.CategoryDtos;
using FoodMartProject.Dtos.FeatureDtos;
using FoodMartProject.Entities;
using FoodMartProject.Settings;
using MongoDB.Driver;

namespace FoodMartProject.Services
{
	public class FeatureService : GenericService<Feature, CreateFeatureDto, UpdateFeatureDto, GetByIdFeatureDto, ResultFeatureDto>, IFeatureService
	{
		public FeatureService(IMapper mapper, IDatabaseSettings databaseSettings) : base(mapper, databaseSettings, databaseSettings.FeatureCollectionName)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
		}
	}
}
