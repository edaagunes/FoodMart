using FoodMartProject.Dtos.MailDtos;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

namespace FoodMartProject.Controllers
{
	public class MailController : Controller
	{
		[HttpPost]
		public IActionResult SendMail(CreateMailDto createMailDto)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("FoodMart", "traversalcoreeda@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress(createMailDto.Name, createMailDto.ReceiverMail);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.HtmlBody = $@"
                <div style='font-family: Arial, sans-serif; line-height: 1.6;'>
                    <h1 style='color: #4CAF50;'>Tebrikler {createMailDto.Name}!</h1>
                    <p>Bizden <strong>%25 indirim kodu</strong> kazandınız!</p>
                    <p>İlk siparişinizde bu kodu kullanarak avantajlardan faydalanabilirsiniz:</p>
                    <div style='padding: 10px; background-color: #f9f9f9; border: 1px solid #ddd; display: inline-block;'>
                        <strong style='font-size: 20px;'>INDIRIM25</strong>
                    </div>
                    <p>Şimdi sipariş vermek için <a href='https://www.foodmart.com' style='color: #007BFF;'>web sitemizi</a> ziyaret edin.</p>
                    <p>Keyifli alışverişler dileriz,<br><strong>FoodMart Ekibi</strong></p>
                </div>";

			// Mesajın Body'si
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			mimeMessage.Subject = "Tebrikler! %25 İndirim Kodunuzu Kazandınız";

			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);
			client.Authenticate("traversalcoreeda@gmail.com", "achk ezrk skqp fzsv");

			client.Send(mimeMessage);
			client.Disconnect(true);

			TempData["Message"] = "Tebrikler! Mail başarıyla gönderildi.";
			return RedirectToAction("Index", "Default");
		}
	}
}
