using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
namespace NoteTaking.Web.Common
{
    /// <summary>
    /// E-mail sender.
    /// </summary>
    public class EmailSender : IEmailSender
    {
        /// <summary>
        /// Sends the e-mail
        /// </summary>
        /// <param name="email">Receiver</param>
        /// <param name="subject">Main subject of the e-mail</param>
        /// <param name="htmlMessage">E-mail message</param>
        /// <returns></returns>
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("valentinmarkov132@gmail.com", "xyswbhjqlhukesbg"),
                EnableSsl = true,
            };

            MailMessage mailMessage = new MailMessage("valentinmarkov132@gmail.com", email, subject, htmlMessage);
            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);
        }
    }
}
