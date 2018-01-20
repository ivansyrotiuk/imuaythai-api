using System.Collections.Generic;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Comparers
{
    public class ContestTypeEqualityComparer :IEqualityComparer<ContestType>
    {
        public bool Equals(ContestType x, ContestType y)
        {
            if (x.Name != y.Name)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(ContestType obj)
        {
            return obj.GetHashCode();
        }
    }
}
