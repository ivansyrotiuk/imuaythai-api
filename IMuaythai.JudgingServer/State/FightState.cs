using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.JudgingServer.State
{
    public class FightState
    {
        private Timer _fightTimer;
        private int _roundTime;
        private int _breakTime;
        public string Mode { get; set; } = "fight";
        public bool Started { get; set; }
        public bool Paused { get; set; }
        public Fighter BlueFighter { get; set; }
        public Fighter RedFighter { get; set; }
        public int Round { get; set; }
        public int Id { get; set; }
        public int RemainingTime { get; set; }

        private readonly ApplicationDbContext _context;

        public FightState(ApplicationDbContext context)
        {
            _context = context;
        }

        private void Execute(Object stateInfo)
        {
            RemainingTime--;
            if (RemainingTime > 0) return;
            _fightTimer.Dispose();
        }

        protected bool Equals(FightState other)
        {
            return BlueFighter.Equals(other.BlueFighter) && RedFighter.Equals(other.RedFighter) && Round == other.Round && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FightState) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = BlueFighter.GetHashCode();
                hashCode = (hashCode * 397) ^ RedFighter.GetHashCode();
                hashCode = (hashCode * 397) ^ Round;
                hashCode = (hashCode * 397) ^ Id;
                return hashCode;
            }
        }
        public void Initialize(int id)
        {
            Id = id;
            var fight = _context.Fights.Include(f => f.Structure).ThenInclude(s => s.Round).FirstOrDefault(f => f.Id == id);
            var points = _context.FightPoints.Where(f => f.FightId == id).ToList();
            foreach (var point in points)
            {
                point.Fight = null;
                point.Judge = null;
                point.Fighter = null;
            }

            if (fight != null)
            {
                var redFighterPoints = points.Where(p => p.FighterId == fight.RedAthleteId).ToList();
                var blueFighterPoints = points.Where(p => p.FighterId == fight.BlueAthleteId).ToList();

                RedFighter = new Fighter(fight.RedAthleteId, redFighterPoints);
                BlueFighter = new Fighter(fight.BlueAthleteId, blueFighterPoints);
                RemainingTime = _roundTime = fight.Structure.Round.Duration * 1000;
                _breakTime = fight.Structure.Round.BreakDuration * 1000;

            }

            Round = points.Count > 0 ? points.Max(p => p.RoundId) : 0;
        }

        public void SetMode(string mode)
        {
            Mode = mode;
            PauseTimer();
            RemainingTime = mode == "fight" ? _roundTime : _breakTime;
        }
        
        

        public void SetPoints(FightPoint points)
        {
            if(points.FighterId == RedFighter.Id)
                RedFighter.SetPoints(points);
            else
                BlueFighter.SetPoints(points);
        }
        public List<FightPoint> GetWarnings()
        {            
            var result = RedFighter.Points.ToList();
            result.AddRange(BlueFighter.Points.ToList());
            return result;
        }

        public void Reset()
        {
            Id = Round = 0;
            RedFighter = BlueFighter = null;
            _fightTimer?.Dispose();
            _roundTime = 0;
            _breakTime = 0;
            Started = false;
            Paused = false;
            RemainingTime = 0;
        }

        public void StartTimer()
        {
            _fightTimer = new Timer(Execute, new AutoResetEvent(false), 1, 1);
        }

        public void PauseTimer()
        {
            _fightTimer?.Dispose();
        }
    }
}
