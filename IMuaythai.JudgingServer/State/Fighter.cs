using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.JudgingServer.State
{
    public class Fighter
    {
        protected bool Equals(Fighter other)
        {
            return Points.All(other.Points.Contains) && Points.Count == other.Points.Count && string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Fighter) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Points.GetHashCode() * 397) ^ Id.GetHashCode();
            }
        }

        public string Id { get; }
        public readonly List<FightPoint> Points;

        public Fighter(string id, List<FightPoint> points)
        {
            Id = id;
            Points = new List<FightPoint>(points);
        }

        public void SetPoints(FightPoint point)
        {
            var pointToUpdate = Points.FirstOrDefault(p =>
                p.FighterId == point.FighterId 
                && p.RoundId == point.RoundId 
                && p.JudgeId == point.JudgeId
                && p.FightId == point.FightId);

            //Can it be mapped or something?
            if (pointToUpdate != null)
            {
                pointToUpdate.Accepted = point.Accepted;
                pointToUpdate.Points = point.Points;
                pointToUpdate.Cautions = point.Cautions;
                pointToUpdate.Warnings = point.Warnings;
                pointToUpdate.KnockDown = point.KnockDown;
                pointToUpdate.X = point.X;
                pointToUpdate.J = point.J;
            }
            else
            {
                Points.Add(point);    
            }
            
        }


    }
}
