using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IContestRangesRepository
    {
        ContestRange Get(int id);
        IEnumerable<ContestRange> GetAll();
        IEnumerable<ContestRange> Find(Func<ContestRange, bool> predicate);
        void Save(ContestRange contestRange);
        void Remove(int id);
    }
}
