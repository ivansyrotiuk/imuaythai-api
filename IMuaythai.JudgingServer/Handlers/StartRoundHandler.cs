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

        public async Task<HandlerResponse> Handle(Message message)
        {
            if (message.RequestType != MessageType.StartRound)
            {
                return NextHandler?.Handle(message).Result;
            }

            if (!FightContext.CanStartNewRound())
            {
                return new HandlerResponse
                {
                    ResponseType = ResponseType.Skip
                };
            }

            FightContext.IncrementRoundNumber();

            var roundId = FightContext.GetRoundNumber();

            return new HandlerResponse
            {
                ResponseType = ResponseType.ToAll,
                Message = new Message
                {
                    RequestType = message.RequestType,
                    Data = roundId.ToString()
                }
            };

        }
    }
}