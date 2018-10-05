using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.Shared;
using IMuaythai.Shared.Extensions;

namespace IMuaythai.JudgingServer.Handlers
{
    class LoadStateHandler : BaseRequestHandler, IMessageHandler
    {
        public LoadStateHandler(IMessageHandler handler, IFightContext fightContext, ApplicationDbContext context) : base(
            handler, fightContext, context)
        {
            
        }

        public Task<HandlerResponse> Handle(Message message)
        {
            if (message.RequestType != MessageType.PersisedState)
            {
                return Task.FromResult(NextHandler?.Handle(message).Result);
            }
            if (FightContext.GetFightId() == 0)
            {
                var fightId = message.Data.ToInt();
                FightContext.InitState(fightId);
            }

            var serializedState = FightContext.GetFightState().Serialize();
            return Task.FromResult( new HandlerResponse
            {
                ResponseType = ResponseType.ToSelf,
                Message = new Message
                {
                    RequestType = MessageType.PersisedState,
                    Data = serializedState
                }
            });
        }
    }
}