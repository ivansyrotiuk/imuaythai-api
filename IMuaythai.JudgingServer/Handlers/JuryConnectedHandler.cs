using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.JudgingServer.Handlers
{
    class JuryConnectedHandler : BaseRequestHandler, IMessageHandler
    {
        public JuryConnectedHandler(IMessageHandler handler, IFightContext fightContext, ApplicationDbContext context) : base(handler, fightContext, context)
        {
        }

        public Task<HandlerResponse> Handle(Message message)
        {
            if (message.RequestType != MessageType.JuryConnected)
            {
                return Task.FromResult(NextHandler?.Handle(message).Result);
            }

            return Task.FromResult(new HandlerResponse
            {
                ResponseType = ResponseType.ToAll,
                Message = new Message
                {
                    RequestType = message.RequestType,
                    Data = "Jury connected"
                }
            });

        }
    }
}