using System;
using System.Collections.Generic;
using System.Text;

namespace MuaythaiSportManagementSystemApi.Models.Comparers
{
    class ContestCategoriesMappingEqualityComparer: IEqualityComparer<ContestCategoriesMapping>
    {
        public bool Equals(ContestCategoriesMapping x, ContestCategoriesMapping y)
        {
            if (x.ContestId != y.ContestId)
            {
                return false;
            }

            if (x.ContestCategoryId != y.ContestCategoryId)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(ContestCategoriesMapping obj)
        {
            return obj.GetHashCode();
        }
    }
}
