namespace FoodMartProject.Dtos.MailDtos
{
	public class CreateMailDto
	{
		public string ReceiverMail { get; set; }
		public string Subject { get; set; } = "FoodMart'a Hoşgeldiniz!";
		public string Name { get; set; }
		public string Body { get; set; }
	}
}
