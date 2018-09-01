using System.Collections.Generic;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Fights.JudgeSelectors
{
    public class InstitutionRestrictedSelector : BaseJudgeSelector
    {
        public InstitutionRestrictedSelector(IFightDurationCalculator fightDurationCalculator) : base(fightDurationCalculator)
        {
        }
        public override bool IsJudgeAppropriated(ContestRequest request, Fight fight, List<Fight> contestFights)
        {
            return base.IsJudgeAppropriated(request, fight, contestFights) &&
                   fight.RedAthlete?.InstitutionId != request.InstitutionId &&
                   fight.BlueAthlete?.InstitutionId != request.InstitutionId;
        }
    }
}
