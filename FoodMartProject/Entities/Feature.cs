using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodMartProject.Entities
{
	public class Feature
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string FeatureId { get; set; }
		public string Image { get; set; }
		public string Header { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
	}
}
