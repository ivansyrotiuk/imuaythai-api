using System.Threading.Tasks;
using IMuaythai.DataAccess;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using IMuaythai.Shared;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.JudgingServer.Handlers
{
    class PrematureEndHandler : BaseRequestHandler, IMessageHandler
    {
        public PrematureEndHandler(IMessageHandler handler, IFightContext fightContext, ApplicationDbContext context) : base(handler, fightContext, context)
        {
        }

        public async Task<HandlerResponse> Handle(Message message)
        {
            if (message.RequestType != MessageType.PrematureEnd)
            {
                return NextHandler?.Handle(message).Result;
            }
            await SaveInjury(message.Data);
            return new HandlerResponse
            {
                ResponseType = ResponseType.ToOne,
                Message = new Message
                {
                    RequestType = message.RequestType,
                    Data = message.Data
                }
            };

        }

        private async Task SaveInjury(string data)
        {
            try
            {
                Context.BeginTransaction();
                var points = data.Deserialize<FightPoint>();
                var fight = await Context.Fights.FirstOrDefaultAsync(f => f.Id == points.FightId);
                var nextFight = await Context.Fights.FirstOrDefaultAsync(f => f.Id == fight.NextFightId);
                if (string.IsNullOrEmpty(fight.WinnerId) && points.Accepted)
                {
                    fight.WinnerId = points.FighterId == fight.BlueAthleteId ? fight.RedAthleteId : fight.BlueAthleteId;
                    nextFight.AssignPrevFightWinner(points.FighterId);
                }

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