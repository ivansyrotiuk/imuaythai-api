using System.Collections.Generic;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.DataAccess.Services.Comparers
{
    public class FightEqualityComparer:IEqualityComparer<Fight>
    {
        public bool Equals(Fight x, Fight y)
        {
            if (x.ContestId != y.ContestId)
            {
                return false;
            }

            if (x.StructureId != y.StructureId)
            {
                return false;
            }

            if (x.ContestCategoryId != y.ContestCategoryId)
            {
                return false;
            }

            if (x.RedAthleteId != y.RedAthleteId)
            {
                return false;
            }

            if (x.BlueAthleteId != y.BlueAthleteId)
            {
                return false;
            }

            if (x.WinnerId != y.WinnerId)
            {
                return false;
            }

            if (x.StartDate != y.StartDate)
            {
                return false;
            }

            if (x.StartNumber != y.StartNumber)
            {
                return false;
            }

            if (x.TimeKeeperId != y.TimeKeeperId)
            {
                return false;
            }

            if (x.RefereeId != y.RefereeId)
            {
                return false;
            }

            if (x.KO != y.KO)
            {
                return false;
            }

            if (x.Ring != y.Ring)
            {
                return false;
            }

            if (x.KOTime != y.KOTime)
            {
                return false;
            }

            if (x.NextFightId != y.NextFightId)
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(Fight obj)
        {
            return obj.GetHashCode();
        }
    }
}
