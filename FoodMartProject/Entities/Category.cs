using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodMartProject.Entities
{
	public class Category
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string Icon { get; set; }
		
	}
}
