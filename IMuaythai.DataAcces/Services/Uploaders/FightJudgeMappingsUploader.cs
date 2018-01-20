using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.DataAccess.Services.Uploaders
{
    public class FightJudgeMappingsUploader : IFightJudgeMappingsUploader
    {
        public Dictionary<int, int> Upload(ApplicationDbContext context, ApplicationDbContext mainContext, int contestId, Dictionary<int, int> fightsIdsDictionary, Dictionary<string, string> usersIdsDictionary)
        {
            mainContext.SaveChanges();
            mainContext.FightJudgesMappings.RemoveRange(mainContext.FightJudgesMappings.Where(mapping => mapping.Fight.ContestId == contestId));
            mainContext.SaveChanges();
            var localMappings =  context.FightJudgesMappings.Where(m => m.Fight.ContestId == contestId).ToList();
          
            foreach (var mapping in localMappings)
            {

                //mainContext.FightJudgesMappings.Add(new FightJudgesMapping
                //{
                //    FightId = fightsIdsDictionary[mapping.FightId],
                //    JudgeId = usersIdsDictionary[mapping.JudgeId],
                //    Main = mapping.Main,
                //});

                //TODO there is some bug
                mainContext.Database.ExecuteSqlCommand(
                    $"INSERT INTO FightJudgesMappings(FightId, JudgeId, Main) Values(@FightId, @JudgeId, @Main)",
                    new SqlParameter("@FightId", fightsIdsDictionary[mapping.FightId]),
                    new SqlParameter("@JudgeId", usersIdsDictionary[mapping.JudgeId]),
                    new SqlParameter("@Main", mapping.Main)
                );

            }

            return new Dictionary<int, int>();
        }
    }
}