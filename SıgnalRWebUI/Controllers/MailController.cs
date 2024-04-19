using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SıgnalRWebUI.DTOs.MailDTOs;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Hosting;

namespace SıgnalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", "projekursapi@gmail.com"); //Mail kimden geleceğini gösterir.
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);  //Mail kime gidecek
            mimeMessage.To.Add(mailboxAddressTo);

            //İçerik ekleme işlemi
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body; ;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            //Konuyu bu şekilde alıyoruz
            mimeMessage.Subject = createMailDto.Subject;

            //Şifreleme yapıyoruz
            //SMTP istemcisini belirtilen sunucuya bağlar. İlk parametre olarak "smtp.gmail.com" SMTP sunucusunun adresini belirtir. İkinci parametre olan 587, SMTP sunucusuna bağlanmak için kullanılacak port numarasını belirtir. Genellikle STARTTLS ile güvenli bağlantı kurulabilen port olan 587'yi kullanır. Üçüncü parametre olan false, bağlantının güvenli olup olmadığını belirtir. Eğer bu parametre true olarak ayarlanırsa, SSL/TLS kullanarak güvenli bir bağlantı kurulur. Ancak, bu örnekte false olarak belirtilmiş, yani güvenli bağlantı kullanılmayacak.

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false); //Port numarası Türkiye'de 587 onun için öyle yaptık
            client.Authenticate("projekursapi@gmail.com", "itcs zbby vbzk uugm"); //Mesajı göndereceğim mail adresi istiyor. itcs zbby vbzk uugm bu bir key ve google heasbı üzerinden aldığım bir şifre random oluşturuldu.(uygulama şifresi)

            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index", "Category");
        }
    }
}
