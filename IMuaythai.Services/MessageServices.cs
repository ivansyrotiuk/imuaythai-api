using System;
using System.Net;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace IMuaythai.Services
{
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public EmailConfiguration Options {get;}
        private readonly ILogger _logger;

        public AuthMessageSender(IOptions<EmailConfiguration> emailOptionsAccessor, ILoggerFactory factory)
        {
            Options = emailOptionsAccessor.Value;
            _logger = factory.CreateLogger<AuthMessageSender>();
        }
        public async Task SendEmailAsync(string email, string subject, string message)
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
            var response = await client.SendEmailAsync(msg);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                var content = await response.Body.ReadAsStringAsync();
                _logger.Log(LogLevel.Error, $"{response.StatusCode}: {content}");
                //SendByNativeSmtp(email, subject, message);
            }
        }
      

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }

        private void SendByNativeSmtp(string email, string subject, string messageText)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("imuaythai", "email_from@example.com"));
            message.To.Add(new MailboxAddress("email_to", "email_to@example.com"));
            message.Subject = "My Subject";

            var builder = new BodyBuilder();

            builder.TextBody = "Body Text";

            message.Body = builder.ToMessageBody();

            try
            {
                var client = new SmtpClient();

                client.Connect("smtp.mailserver.com", 465, true);
                client.Authenticate("usernmae", "password");
                client.Send(message);
                client.Disconnect(true);

                Console.WriteLine("Send Mail Success.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Send Mail Failed : " + e.Message);
            }
        }
    }
}
