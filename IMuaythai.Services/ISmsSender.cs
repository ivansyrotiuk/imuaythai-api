using System.Threading.Tasks;

namespace IMuaythai.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
