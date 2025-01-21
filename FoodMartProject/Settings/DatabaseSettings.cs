namespace FoodMartProject.Settings
{
	public class DatabaseSettings : IDatabaseSettings
	{
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
		public string CategoryCollectionName { get; set; }
		public string DiscountCollectionName { get; set; }
		public string FeatureCollectionName { get; set; }
		public string ProductCollectionName { get; set; }
		public string SellingCollectionName { get; set; }
	}
}
