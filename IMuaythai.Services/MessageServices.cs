using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace IMuaythai.Services
{
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public EmailConfiguration Options {get;}

        public AuthMessageSender(IOptions<EmailConfiguration> emailOptionsAccessor)
        {
            Options = emailOptionsAccessor.Value;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(Options.SendGridApiKey);
            var msg = new SendGridMessage
            {
                From = new EmailAddress(Options.SmtpEmail, "IMuaythai"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);       
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
