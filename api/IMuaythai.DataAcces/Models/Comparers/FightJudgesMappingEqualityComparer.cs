using System.Collections.Generic;

namespace IMuaythai.DataAccess.Models.Comparers
{
    public class FightJudgesMappingEqualityComparer:IEqualityComparer<FightJudgesMapping>
    {
        public bool Equals(FightJudgesMapping x, FightJudgesMapping y)
        {
            if (x.FightId != y.FightId)
            {
                return false;
            }

            if (x.JudgeId != y.JudgeId)
            {
                return false;
            }

            if (x.Main != y.Main)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(FightJudgesMapping obj)
        {
            return obj.GetHashCode();
        }
    }
}
