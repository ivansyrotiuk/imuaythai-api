using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class FightPointsUploader : IFightPointsUploader
    {
        public void Upload(ApplicationDbContext context, ApplicationDbContext mainContext, Dictionary<int, int> fightsIdsDictionary, Dictionary<string, string> usersIdsDictionary)
        {
            var localFightsIds = fightsIdsDictionary.Select(fightId => fightId.Key).ToList();
            var remoteFightsIds = fightsIdsDictionary.Select(fightId => fightId.Value).ToList();

            var localPoints = context.FightPoints.Where(point => localFightsIds.Contains(point.FightId)).ToList();
            mainContext.FightPoints.RemoveRange(mainContext.FightPoints.Where(point => remoteFightsIds.Contains(point.FightId)));
            localPoints.ForEach(points => points.NullReferencePropeties());
            localPoints.ForEach(point =>
            {
                point.Id = 0;
                point.FightId = fightsIdsDictionary[point.FightId];
                point.FighterId = usersIdsDictionary[point.FighterId];
                point.JudgeId = usersIdsDictionary[point.JudgeId];
            });

            mainContext.FightPoints.AddRange(localPoints);
            mainContext.SaveChanges();
        }
    }
}