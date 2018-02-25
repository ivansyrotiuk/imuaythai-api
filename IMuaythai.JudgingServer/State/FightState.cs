using System.Collections.Generic;
using System.Linq;
using System.Threading;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.JudgingServer.State
{
    class FightState
    {
        public Timer FightTimer { get; private set; }

        public Fighter BlueFighter { get; private set; }
        public Fighter RedFighter { get; private set; }
        public int Round { get; private set; }
        private readonly int _id;
        private readonly ApplicationDbContext _context;

        public FightState(int id, ApplicationDbContext context)
        {
            _id = id;
            _context = context;
            Initialize();
        }

        private void Initialize()
        {
            var fight = _context.Fights.FirstOrDefault(f => f.Id == _id);
            var points = _context.FightPoints.Where(f => f.FightId == _id);

            var redFighterPoints = points.Where(p => p.FighterId == fight.RedAthleteId).ToList();
            var blueFighterPoints = points.Where(p => p.FighterId == fight.BlueAthleteId).ToList();

            if (fight != null)
            {
                RedFighter = new Fighter(fight.RedAthleteId, redFighterPoints);
                BlueFighter = new Fighter(fight.BlueAthleteId, blueFighterPoints);
            }

            Round = points.Max(p => p.RoundId);


            //FightTimer = new Timer();

        }

        public void SetPoints(FightPoint points)
        {
            if(points.FighterId == RedFighter.Id)
                RedFighter.SetPoints(points);
            else
                BlueFighter.SetPoints(points);
        }
    }
}
