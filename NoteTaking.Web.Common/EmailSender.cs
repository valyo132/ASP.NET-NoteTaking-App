using Microsoft.AspNetCore.Identity.UI.Services;

namespace NoteTaking.Web.Common
{
    /// <summary>
    /// Email sender.
    /// </summary>
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
