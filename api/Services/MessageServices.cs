using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace MuaythaiSportManagementSystemApi.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public EmailConfiguration Options {get;}
        public AuthMessageSender(IOptions<EmailConfiguration> emailOptionsAccessor)
        {
            Options = emailOptionsAccessor.Value;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            MimeMessage emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("iMuayThai", Options.SmtpEmail));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            
            BodyBuilder bodyBuilder = new BodyBuilder{
                HtmlBody = message
            };

            emailMessage.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect(Options.SmtpServer, 587);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(Options.SmtpUsername, Options.SmtpPassword);
            return client.SendAsync(emailMessage);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
