using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class FightsUploader : IFightsUploader
    {
        public Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext, int contestId, Dictionary<string, string> usersIdsDictionary)
        {
            var localFights =  context.Fights.Where(fight => fight.ContestId == contestId).OrderBy(fight => fight.Id).ToList();
            var fightsIdsDictionary = localFights.ToDictionary(fight => fight.Id, fight => fight.Id);

            localFights.ForEach(fight => fight.NullReferencePropeties());

            mainContext.Fights.RemoveRange(mainContext.Fights.Where(fight => fight.ContestId == contestId));
             mainContext.SaveChanges();
          

            foreach (var fight in localFights)
            {
                fight.NextFightId = fight.NextFightId.HasValue ? fightsIdsDictionary[fight.NextFightId.Value] : default(int?);
                fight.BlueAthleteId = !string.IsNullOrEmpty(fight.BlueAthleteId) ? usersIdsDictionary[fight.BlueAthleteId] : null;
                fight.RedAthleteId = !string.IsNullOrEmpty(fight.RedAthleteId) ? usersIdsDictionary[fight.RedAthleteId] : null;
                fight.RefereeId = !string.IsNullOrEmpty(fight.RefereeId) ? usersIdsDictionary[fight.RefereeId] : null;
                fight.TimeKeeperId = !string.IsNullOrEmpty(fight.TimeKeeperId) ? usersIdsDictionary[fight.TimeKeeperId] : null;
                fight.FightJudgesMappings = null;
                var fightId = fight.Id;
                fight.Id = 0;
                mainContext.Fights.Add(fight);
                 mainContext.SaveChanges();
                fightsIdsDictionary[fightId] = fight.Id;
            }

            //mainContext.Fights.AddRange(localFights);
            // mainContext.SaveChanges();

            return fightsIdsDictionary;
        }
    }
}