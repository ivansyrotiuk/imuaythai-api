using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Fights.JudgeSelectors
{
    public abstract class BaseJudgeSelector : IAppropriateJudgeSelector
    {
        public readonly IFightDurationCalculator FightDurationCalculator;

        protected BaseJudgeSelector(IFightDurationCalculator fightDurationCalculator)
        {
            FightDurationCalculator = fightDurationCalculator;
        }

        public virtual string SelectJudgeForFight(Fight fight, List<Fight> contestFights, List<ContestRequest> judgeRequests)
        {
            foreach (var request in judgeRequests)
            {
                var isJudgeAppropriated = IsJudgeAppropriated(request, fight, contestFights);

                if (isJudgeAppropriated)
                {
                    return request.UserId;
                }
            }
            //todo throw exception No appropriated judges found
            return string.Empty;
        }

        public virtual bool IsJudgeAppropriated(ContestRequest request, Fight fight, List<Fight> contestFights)
        {
            var fightDuration = FightDurationCalculator.CalculateFightDuration(fight.Structure.Round);

            var assignedFights = contestFights.Where(f =>
                f.FightJudgesMappings != null && f.FightJudgesMappings.Any(m => m.JudgeId == request.UserId) ||
                 f.RefereeId == request.UserId || f.TimeKeeperId == request.UserId).ToArray();

            return assignedFights.Length == 0 || assignedFights.All(f =>
                       f.StartDate < fight.StartDate?.Add(-fightDuration) &&
                       f.StartDate > fight.StartDate?.Add(fightDuration));
        }
    }
}
