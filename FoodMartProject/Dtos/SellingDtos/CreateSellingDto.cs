namespace FoodMartProject.Dtos.SellingDtos
{
	public class CreateSellingDto
	{
		public string ProductId { get; set; }
		public int Count { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime SellingDate { get; set; }
	}
}
