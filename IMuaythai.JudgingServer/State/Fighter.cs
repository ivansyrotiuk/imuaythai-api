using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.JudgingServer.State
{
    class Fighter
    {
        public string Id { get; }
        public readonly List<FightPoint> Points;

        public Fighter(string id, List<FightPoint> points)
        {
            Id = id;
            Points = new List<FightPoint>(points);
        }

        public void SetPoints(FightPoint point)
        {
            var existingPoints = Points.Where(p => p.)
            Points.Add(point);
        }


    }
}
