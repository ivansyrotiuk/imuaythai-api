using System.Threading.Tasks;

namespace IMuaythai.Api.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
