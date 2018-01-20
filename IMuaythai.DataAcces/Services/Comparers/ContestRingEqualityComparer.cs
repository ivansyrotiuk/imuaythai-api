using System.Collections.Generic;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Comparers
{
    public class ContestRingEqualityComparer : IEqualityComparer<ContestRing>
    {
        public bool Equals(ContestRing x, ContestRing y)
        {
            if (x.Name != y.Name)
            {
                return false;
            }

            if (x.From != y.From)
            {
                return false;
            }

            if (x.To != y.To)
            {
                return false;
            }

            if (x.ContestId != y.ContestId)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(ContestRing obj)
        {
            return obj.GetHashCode();
        }
    }
}
