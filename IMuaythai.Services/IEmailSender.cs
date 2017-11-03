using System.Threading.Tasks;

namespace IMuaythai.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
