using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.JudgingServer.Handlers
{
    class JuryConnectedHandler : BaseRequestHandler, IMessageHandler
    {
        public JuryConnectedHandler(IMessageHandler handler, IFightContext fightContext, ApplicationDbContext context) : base(handler, fightContext, context)
        {
        }

        public async Task<HandlerResponse> Handle(Message message)
        {
            if (message.RequestType != MessageType.JuryConnected)
            {
                return NextHandler?.Handle(message).Result;
            }

            return new HandlerResponse
            {
                ResponseType = ResponseType.ToAll,
                Message = new Message
                {
                    RequestType = message.RequestType,
                    Data = "Jury connected"
                }
            };

        }
    }
}