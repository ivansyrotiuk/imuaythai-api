using System;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using IMuaythai.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.JudgingServer.Handlers
{
    class EndFightHandler : BaseRequestHandler, IMessageHandler
    {
        public EndFightHandler(IMessageHandler handler, IFightContext fightContext,
            ApplicationDbContext context) : base(handler, fightContext, context)
        {
        }

        public async Task<HandlerResponse> Handle(Message message)
        {
            if (message.RequestType != MessageType.EndFight)
            {
                return NextHandler?.Handle(message).Result;
            }


            FightContext.ResetState();

            await SaveWinner(message.Data);

            return new HandlerResponse
            {
                ResponseType = ResponseType.ToAll,
                Message = new Message
                {
                    RequestType = message.RequestType
                }
            };
        }

        private async Task SaveWinner(string data)
        {
            try
            {
                Context.BeginTransaction();
                var fight = await Context.Fights.FirstOrDefaultAsync(f => f.Id == data.ToInt());
                var nextFight = await Context.Fights.FirstOrDefaultAsync(f => f.Id == fight.NextFightId);
                if (!string.IsNullOrEmpty(fight.WinnerId)) return;

                var totalBluePoints = CalculateTotalPoints(fight.BlueAthleteId, fight.Id);
                var totalRedPoints = CalculateTotalPoints(fight.RedAthleteId, fight.Id);

                if (Math.Abs(totalBluePoints.Result) < 0 || Math.Abs(totalRedPoints.Result) < 0)
                    return;

                if (totalBluePoints.Result > totalRedPoints.Result)
                {
                    fight.WinnerId = fight.BlueAthleteId;
                    nextFight.AssignPrevFightWinner(fight.BlueAthleteId);
                }

                else
                {
                    fight.WinnerId = fight.RedAthleteId;
                    nextFight.AssignPrevFightWinner(fight.RedAthleteId);
                }

                await Context.SaveChangesAsync();
                Context.CommitTransaction();
            }
            catch
            {
                Context.RollbackTransaction();
                throw;
            }
        }

        private async Task<float> CalculateTotalPoints(string blueAthleteId, int id)
        {
            var points = await Context.FightPoints
                .Where(f => f.FightId == id && f.FighterId == blueAthleteId && f.Accepted).ToListAsync();
            return points.GroupBy(p => p.RoundId).Select(g => new
                {
                    RoundId = g.Key,
                    Points = CalculateMedian(g)
                })
                .ToList()
                .Sum(s => s.Points);
        }

        private float CalculateMedian(IGrouping<int, FightPoint> g)
        {
            var count = g.Count();
            var orderedPoints = g.OrderBy(p => p.Points);
            float median = orderedPoints.ElementAt(count / 2).Points + orderedPoints.ElementAt((count - 1) / 2).Points;
            return median / 2;
        }
    }
}