using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Timers;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using IMuaythai.Shared.Extensions;

namespace IMuaythai.JudgingServer.State
{
    public class FightState
    {
        private Timer _fightTimer;

        public Fighter BlueFighter { get; set; }
        public Fighter RedFighter { get; set; }
        public int Round { get; set; }
        public int Id { get; set; }
        private readonly ApplicationDbContext _context;

        public FightState(ApplicationDbContext context)
        {
            _context = context;
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
            var fight = _context.Fights.FirstOrDefault(f => f.Id == id);
            var points = _context.FightPoints.Where(f => f.FightId == id).ToList();

            var redFighterPoints = points.Where(p => p.FighterId == fight.RedAthleteId).ToList();
            var blueFighterPoints = points.Where(p => p.FighterId == fight.BlueAthleteId).ToList();

            if (fight != null)
            {
                RedFighter = new Fighter(fight.RedAthleteId, redFighterPoints);
                BlueFighter = new Fighter(fight.BlueAthleteId, blueFighterPoints);
            }

            Round = points.Count > 0 ? points.Max(p => p.RoundId) : 0;


            _fightTimer = new Timer();
        }

        public void SetPoints(FightPoint points)
        {
            if(points.FighterId == RedFighter.Id)
                RedFighter.SetPoints(points);
            else
                BlueFighter.SetPoints(points);
        }

        public Dictionary<string, int> GetWarnings()
        {
            var redFighterWarnings = ToWarningDictionary(RedFighter.Points);
            var blueFighterWanings = ToWarningDictionary(BlueFighter.Points);
            
            var result = redFighterWarnings.Union(blueFighterWanings).ToDictionary(p => p.Key, p => p.Key.ToInt());

            return result;
        }

        private Dictionary<string, int> ToWarningDictionary(List<FightPoint> pointsList)
        {
            var dictionary = new Dictionary<string,int>();
            foreach (var fightPoint in pointsList)
            {
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(fightPoint))
                {
                    var value = property.GetValue(fightPoint);
                    if (!(value is int)) continue;
                    
                    if(!dictionary.ContainsKey(property.Name))
                        dictionary.Add(property.Name, value.ToInt());
                    dictionary[property.Name] += value.ToInt();
                }
            }
            return dictionary;
        }

        public void Reset()
        {
            Id = Round = 0;
            RedFighter = BlueFighter = null;
        }
    }
}
