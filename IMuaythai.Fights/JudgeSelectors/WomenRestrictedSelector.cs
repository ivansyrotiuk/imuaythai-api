using System.Collections.Generic;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Fights.JudgeSelectors
{
    public class WomenRestrictedSelector : BaseJudgeSelector
    {
        private const string Female = "female";
        private readonly BaseJudgeSelector _judgeSelector;
        public WomenRestrictedSelector(BaseJudgeSelector judgeSelector) : base(judgeSelector.FightDurationCalculator)
        {
            _judgeSelector = judgeSelector;
        }

        public override bool IsJudgeAppropriated(ContestRequest request, Fight fight, List<Fight> contestFights)
        {
            var isJudgeAppropriated = _judgeSelector.IsJudgeAppropriated(request, fight, contestFights);
            if (fight.BlueAthlete.Gender != Female)
            {
                return isJudgeAppropriated;
            }

            return isJudgeAppropriated && request.User.Gender == Female;
        }
    }
}