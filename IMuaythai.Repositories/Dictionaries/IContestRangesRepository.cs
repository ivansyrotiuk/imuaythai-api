using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Dictionaries
{
    public interface IContestRangesRepository
    {
        Task<ContestRange> Get(int id);
        Task<List<ContestRange>> GetAll();
        Task<List<ContestRange>> Find(Func<ContestRange, bool> predicate);
        Task Save(ContestRange contestRange);
        Task Remove(int id);
    }
}
