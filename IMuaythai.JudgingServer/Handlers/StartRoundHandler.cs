using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.JudgingServer.Handlers
{
    class StartRoundHandler : BaseRequestHandler, IMessageHandler
    {
        public StartRoundHandler(IMessageHandler handler, IFightContext fightContext,
            ApplicationDbContext context) : base(handler, fightContext, context)
        {

        }

        public Task<HandlerResponse> Handle(Message message)
        {
            if (message.RequestType != MessageType.StartRound)
            {
                return Task.FromResult(NextHandler?.Handle(message).Result);
            }

            if (!FightContext.CanStartNewRound())
            {
                return Task.FromResult(new HandlerResponse
                {
                    ResponseType = ResponseType.Skip
                });
            }
            FightContext.StartRound();
            var roundId = FightContext.GetRoundNumber();
            
            return Task.FromResult(new HandlerResponse
            {
                ResponseType = ResponseType.ToAll,
                Message = new Message
                {
                    RequestType = message.RequestType,
                    Data = roundId.ToString()
                }
            });

        }
    }
}