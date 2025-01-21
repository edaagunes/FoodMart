using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodMartProject.Entities
{
	public class Selling
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string SellingId { get; set; }

		[BsonRepresentation(BsonType.ObjectId)]
		public string ProductId { get; set; }
		[BsonIgnore]
		public Product Product { get; set; }
		public int Count { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime SellingDate { get; set; }
	}
}
