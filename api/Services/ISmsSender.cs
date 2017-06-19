using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
