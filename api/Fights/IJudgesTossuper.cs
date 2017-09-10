using MuaythaiSportManagementSystemApi.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Fights
{
    public interface IJudgesTossuper
    {
        Task<List<Fight>> Tossup(List<ContestRequest> judgesRequests, List<Fight> fights);
    }

    public class JudgesTossuper : IJudgesTossuper
    {
        public async Task<List<Fight>> Tossup(List<ContestRequest> judgesRequests, List<Fight> fights)
        {
            foreach(var fight in fights)
            {
                fight.RefereeId = GetFightReferee(fight, judgesRequests);
                fight.TimeKeeperId = GetFightTimeKeepper(fight, judgesRequests);
                fight.FightJudgesMappings = new List<FightJudgesMapping>();

                string mainJudgeId = GetFightMainJudge(fight, judgesRequests);
                fight.FightJudgesMappings.Add(new FightJudgesMapping
                {
                    FightId = fight.Id,
                    JudgeId = mainJudgeId,
                    Main = 1
                });

                var regularJudges = GetRegularJudge(fight, judgesRequests);
                foreach (var judgeId in regularJudges)
                {
                    fight.FightJudgesMappings.Add(new FightJudgesMapping
                    {
                        FightId = fight.Id,
                        JudgeId = judgeId
                    });
                }

            }

            return fights;
        }

        private string GetFightMainJudge(Fight fight, List<ContestRequest> judgesRequests)
        {
            return judgesRequests.Where(request => request.JudgeType == ContestJudgeType.MainJudge)
                .Select(request => request.UserId)
                .FirstOrDefault();
        }

        private IEnumerable<string> GetRegularJudge(Fight fight, List<ContestRequest> judgesRequests)
        {
            return judgesRequests.Where(request => request.JudgeType == ContestJudgeType.Regular)
                .Select(request => request.UserId).OrderBy(request => Guid.NewGuid().ToString()).Take(3)
                .ToList();
        }

        private string GetFightTimeKeepper(Fight fight, List<ContestRequest> judgesRequests)
        {
            return judgesRequests.Where(request => request.JudgeType == ContestJudgeType.TimeKeepper)
                .Select(request => request.UserId)
                .FirstOrDefault();
        }

        private string GetFightReferee(Fight fight, List<ContestRequest> judgesRequests)
        {
            return judgesRequests.Where(request => request.JudgeType == ContestJudgeType.Referee)
                .Select(request => request.UserId)
                .FirstOrDefault();
        }
    }
}
