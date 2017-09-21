using System;
using System.Collections.Generic;
using System.Text;

namespace MuaythaiSportManagementSystemApi.Models.Comparers
{
    public class ContestCategoryEqualityComparer:IEqualityComparer<ContestCategory>
    {
        public bool Equals(ContestCategory x, ContestCategory y)
        {
            if (x.ContestTypePointsId != y.ContestTypePointsId)
            {
                return false;

            }
            if (x.FightStructureId != y.FightStructureId)
            {
                return false;
            }

            if (x.InstitutionId != y.InstitutionId)
            {
                return false;
            }

            if (x.ServiceBreakDuration != y.ServiceBreakDuration)
            {
                return false;
            }

            if (x.Name != y.Name)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(ContestCategory obj)
        {
            return obj.GetHashCode();
        }
    }
}
