using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.JudgingServer.Handlers
{
     class ResumeRoundHandler : BaseRequestHandler, IMessageHandler
    {
        public ResumeRoundHandler(IMessageHandler handler, IFightContext fightContext, ApplicationDbContext context) :
            base(
                handler, fightContext, context)
        {
            
        }

        public async Task<HandlerResponse> Handle(Message message)
        {
            if (message.RequestType != MessageType.ResumeRound)
            {
                return NextHandler?.Handle(message).Result;
            }
            
            FightContext.ResumeRound();
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