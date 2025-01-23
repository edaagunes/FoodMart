namespace FoodMartProject.Dtos.SellingDtos
{
	public class GetByIdSellingDto
	{
		public string SellingId { get; set; }
		public string ProductId { get; set; }
		public int Count { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime SellingDate { get; set; }
	}
}
