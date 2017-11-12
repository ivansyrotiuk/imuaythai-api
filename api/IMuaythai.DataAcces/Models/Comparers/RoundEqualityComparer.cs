using System.Collections.Generic;

namespace IMuaythai.DataAccess.Models.Comparers
{
    public class RoundEqualityComparer:IEqualityComparer<Round>
    {
        public bool Equals(Round x, Round y)
        {
            if (x.Name != y.Name)
            {
                return false;
            }

            if (x.BreakDuration != y.BreakDuration)
            {
                return false;
            }

            if (x.Duration != y.Duration)
            {
                return false;
            }

            if (x.RoundsCount != y.RoundsCount)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(Round obj)
        {
            return obj.GetHashCode();
        }
    }
}
