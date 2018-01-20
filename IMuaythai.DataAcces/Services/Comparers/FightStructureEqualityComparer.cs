using System.Collections.Generic;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Comparers
{
    public class FightStructureEqualityComparer:IEqualityComparer<FightStructure>
    {
        public bool Equals(FightStructure x, FightStructure y)
        {
            if (x.RoundId != y.RoundId)
            {
                return false;
            }

            if (x.WeightAgeCategoryId != y.WeightAgeCategoryId)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(FightStructure obj)
        {
            return obj.GetHashCode();
        }
    }
}
