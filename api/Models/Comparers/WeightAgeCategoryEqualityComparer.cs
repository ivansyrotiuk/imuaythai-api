using System;
using System.Collections.Generic;
using System.Text;

namespace MuaythaiSportManagementSystemApi.Models.Comparers
{
    public class WeightAgeCategoryEqualityComparer:IEqualityComparer<WeightAgeCategory>
    {
        public bool Equals(WeightAgeCategory x, WeightAgeCategory y)
        {
            if (x.Name != y.Name)
            {
                return false;
            }

            if (x.Gender != y.Gender)
            {
                return false;
            }

            if (x.MaxAge != y.MaxAge)
            {
                return false;
            }

            if (x.MaxWeight != y.MaxWeight)
            {
                return false;
            }

            if (x.MinAge != y.MinAge)
            {
                return false;
            }

            if (x.MinWeight != y.MinWeight)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(WeightAgeCategory obj)
        {
            return obj.GetHashCode();
        }
    }
}
