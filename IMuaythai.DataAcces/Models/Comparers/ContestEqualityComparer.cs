using System.Collections.Generic;

namespace IMuaythai.DataAccess.Models.Comparers
{
    public class ContestEqualityComparer:IEqualityComparer<Contest>
    {
        public bool Equals(Contest x, Contest y)
        {
            if (x.Name != y.Name)
            {
                return false;
            }

            if (x.Date != y.Date)
            {
                return false;
            }

            if (x.Duration != y.Duration)
            {
                return false;
            }

            if (x.RingsCount != y.RingsCount)
            {
                return false;
            }

            if (x.InstitutionId != y.InstitutionId)
            {
                return false;
            }

            if (x.CountryId != y.CountryId)
            {
                return false;
            }

            if (x.ContestRangeId != y.ContestRangeId)
            {
                return false;
            }

            if (x.ContestTypeId != y.ContestTypeId)
            {
                return false;
            }

            if (x.Address != y.Address)
            {
                return false;
            }

            if (x.City != y.City)
            {
                return false;
            }

            if (x.Website != y.Website)
            {
                return false;
            }

            if (x.Facebook != y.Facebook)
            {
                return false;
            }
            if (x.Instagram != y.Instagram)
            {
                return false;
            }

            if (x.VK != y.VK)
            {
                return false;
            }

            if (x.Twitter != y.Twitter)
            {
                return false;
            }

            if (x.WaiKhruTime != y.WaiKhruTime)
            {
                return false;
            }

            if (x.AllowUnassociated != y.AllowUnassociated)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(Contest obj)
        {
            return obj.GetHashCode();
        }
    }
}
