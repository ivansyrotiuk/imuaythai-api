using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.JudgingServer.Handlers
{
    class ShowPrematureEndPanelHandler : BaseRequestHandler, IMessageHandler
    {
        public ShowPrematureEndPanelHandler(IMessageHandler handler, IFightContext fightContext, ApplicationDbContext context) : base(handler, fightContext, context)
        {
        }

        public async Task<HandlerResponse> Handle(Message message)
        {
            if (message.RequestType != MessageType.ShowPrematureEndPanel)
            {
                return NextHandler?.Handle(message).Result;
            }

            return new HandlerResponse
            {
                ResponseType = ResponseType.ToAll,
                Message = message
            };
        }
    }
}