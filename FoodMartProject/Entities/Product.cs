using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodMartProject.Entities
{
	public class Product
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ProductId { get; set; }
		public string ProductName { get; set; }
		public int ProductStock { get; set; }
		public decimal ProductPrice { get; set; }
		public string ProductImage { get; set; }

		[BsonRepresentation(BsonType.ObjectId)]
		public string CategoryId { get; set; }
		[BsonIgnore]
		public Category Category { get; set; }
	}
}
