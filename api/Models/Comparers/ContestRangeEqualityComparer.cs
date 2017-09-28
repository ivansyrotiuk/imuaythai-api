using System;
using System.Collections.Generic;
using System.Text;

namespace MuaythaiSportManagementSystemApi.Models.Comparers
{
    public class ContestRangeEqualityComparer:IEqualityComparer<ContestRange>
    {
        public bool Equals(ContestRange x, ContestRange y)
        {
            if (x.Name != y.Name)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(ContestRange obj)
        {
            return obj.GetHashCode();
        }
    }
}
