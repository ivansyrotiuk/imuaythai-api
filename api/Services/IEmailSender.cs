using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
