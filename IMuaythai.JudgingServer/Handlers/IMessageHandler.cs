using System.Threading.Tasks;

namespace IMuaythai.JudgingServer.Handlers
{
    public interface IMessageHandler
    {
        Task<HandlerResponse> Handle(Message message);
    }
}
