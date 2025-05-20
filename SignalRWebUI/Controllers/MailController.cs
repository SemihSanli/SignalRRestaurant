using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.DTOs.MailDTOs;


namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDTOs createMailDTOs)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", "mail kaldırılmıştır buraya mail eklenmelidir");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAdressTo = new MailboxAddress("User", createMailDTOs.ReceiverMail);
            mimeMessage.To.Add(mailboxAdressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDTOs.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject=createMailDTOs.Subject;

           SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("mail kaldırılmıştır buraya mail eklenmelidir", "api key kaldırılmıştır. Buraya key eklenmelidir");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            
            return RedirectToAction("Index", "ProgressBars");
           
        }
    }
}
