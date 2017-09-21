using System;
using System.Collections.Generic;
using System.Text;

namespace MuaythaiSportManagementSystemApi.Models.Comparers
{
    public class ContestRequestEqualityComparer : IEqualityComparer<ContestRequest>
    {
        public bool Equals(ContestRequest x, ContestRequest y)
        {
            if (x.Type != y.Type)
            {
                return false;
            }

            if (x.JudgeType != y.JudgeType)
            {
                return false;
            }

            if (x.IssueDate != y.IssueDate)
            {
                return false;
            }

            if (x.Status != y.Status)
            {
                return false;
            }

            if (x.UserId != y.UserId)
            {
                return false;
            }

            if (x.InstitutionId != y.InstitutionId)
            {
                return false;
            }

            if (x.ContestId != y.ContestId)
            {
                return false;
            }

            if (x.ContestCategoryId != y.ContestCategoryId)
            {
                return false;
            }

            if (x.AcceptedByUserId != y.AcceptedByUserId)
            {
                return false;
            }

            if (x.AcceptanceDate != y.AcceptanceDate)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(ContestRequest obj)
        {
            return obj.GetHashCode();
        }
    }
}
