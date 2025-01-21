using FoodMartProject.Settings;
using MongoDB.Driver;

namespace FoodMartProject.Services
{
	public abstract class BaseMongoService<T> where T : class
	{
		protected readonly IMongoCollection<T> _collection;

		protected BaseMongoService(IDatabaseSettings databaseSettings, string collectionName)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_collection = database.GetCollection<T>(collectionName);
		}
	}
}
