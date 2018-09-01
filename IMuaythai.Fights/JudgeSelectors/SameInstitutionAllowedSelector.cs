using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Fights.JudgeSelectors
{
    public class SameInstitutionAllowedSelector : BaseJudgeSelector
    {
        public SameInstitutionAllowedSelector(IFightDurationCalculator fightDurationCalculator) : base(fightDurationCalculator)
        {
        }
    }
}
