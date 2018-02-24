using System.Threading.Tasks;
using IMuaythai.DataAccess;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using IMuaythai.Shared;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.JudgingServer.Handlers
{
    class AcceptPointsHandler: BaseRequestHandler, IMessageHandler
    {
        public AcceptPointsHandler(IMessageHandler handler, IFightContext fightContext, ApplicationDbContext context):base(handler, fightContext, context)
        {
        }

        public async Task<HandlerResponse> Handle(Message message)
        {
            if (message.RequestType != MessageType.AcceptPoints)
            {
                return NextHandler?.Handle(message).Result;
            }

            await AcceptPoints(message.Data);

            return new HandlerResponse
                {
                    ResponseType = ResponseType.ToAll,
                    Message = new Message
                    {
                        RequestType = message.RequestType,
                        Data = "Points has been accepted"
                    }
                };
        }

        private async Task AcceptPoints(string data)
        {
            try
            {
                Context.BeginTransaction();
                var pointsArray = data.Deserialize<string[]>();
                foreach (var pointString in pointsArray)
                {
                    var points = pointString.Deserialize<FightPoint>();
                    var entityPoints = await Context.FightPoints.FirstOrDefaultAsync(f =>
                        f.FighterId == points.FighterId
                        && f.JudgeId == points.JudgeId
                        && f.RoundId == points.RoundId
                        && f.FightId == points.FightId);

                    if (entityPoints == null)
                    {
                        continue;
                    }

                    entityPoints.Accepted = points.Accepted;
                    entityPoints.Points = points.Points;

                    await Context.SaveChangesAsync();
                }
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
