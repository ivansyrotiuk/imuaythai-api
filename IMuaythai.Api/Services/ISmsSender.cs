using System.Threading.Tasks;

namespace IMuaythai.Api.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
