using System.Threading.Tasks;
using IMuaythai.DataAccess;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using IMuaythai.Shared;

namespace IMuaythai.JudgingServer.Handlers
{
    class SendPointsHandler : BaseRequestHandler, IMessageHandler
    {
        public SendPointsHandler(IMessageHandler handler, IFightContext fightContext, ApplicationDbContext context) : base(handler, fightContext, context)
        {
        }

        public async Task<HandlerResponse> Handle(Message message)
        {
            if (message.RequestType != MessageType.SendPoints)
            {
                return NextHandler?.Handle(message).Result;
            }

            await SavePoints(message.Data);

            return new HandlerResponse
            {
                ResponseType = ResponseType.ToOne,
                Message = new Message
                {
                    RequestType = message.RequestType,
                    Data = "Points has been accepted"
                }
            };
        }

        private async Task SavePoints(string data)
        {
            try
            {
                Context.BeginTransaction();
                var points = data.Deserialize<FightPoint>();
                FightContext.RegisterPoints(points);
                Context.FightPoints.Add(points);
                await Context.SaveChangesAsync();
                Context.CommitTransaction();
            }
            catch
            {
                Context.RollbackTransaction();
                throw;
            }
        }
    }
}