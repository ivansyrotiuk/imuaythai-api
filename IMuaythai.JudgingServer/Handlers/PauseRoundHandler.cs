using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.JudgingServer.Handlers
{
     class PauseRoundHandler : BaseRequestHandler, IMessageHandler
    {
        public PauseRoundHandler(IMessageHandler handler, IFightContext fightContext, ApplicationDbContext context) :
            base(
                handler, fightContext, context)
        {
            
        }

        public async Task<HandlerResponse> Handle(Message message)
        {
            if (message.RequestType != MessageType.PauseRound)
            {
                return NextHandler?.Handle(message).Result;
            }
            
            FightContext.PauseRound();
            return new HandlerResponse
            {
                ResponseType = ResponseType.ToAll,
                Message = new Message
                {
                    RequestType = message.RequestType,
                    Data = null
                }
            };
        }
    }
}