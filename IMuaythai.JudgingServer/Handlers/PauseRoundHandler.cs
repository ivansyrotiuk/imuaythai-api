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

        public Task<HandlerResponse> Handle(Message message)
        {
            if (message.RequestType != MessageType.PauseRound)
            {
                return Task.FromResult( NextHandler?.Handle(message).Result);
            }
            
            FightContext.PauseRound();
            return Task.FromResult(new HandlerResponse
            {
                ResponseType = ResponseType.ToAll,
                Message = new Message
                {
                    RequestType = message.RequestType,
                    Data = null
                }
            });
        }
    }
}