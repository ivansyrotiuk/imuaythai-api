﻿using System.Collections.Generic;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Comparers
{
    public class ContestTypePointsEqualityComparer:IEqualityComparer<ContestTypePoints>
    {
        public bool Equals(ContestTypePoints x, ContestTypePoints y)
        {
            if (x.Points != y.Points)
            {
                return false;
            }

            if (x.ContestTypeId != y.ContestTypeId)
            {
                return false;
            }

            if (x.ContestRangeId != y.ContestRangeId)
            {
                return false;
            }

            if (x.InstitutionId != y.InstitutionId)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(ContestTypePoints obj)
        {
            return obj.GetHashCode();
        }
    }
}
