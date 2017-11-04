using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Dictionaries
{
    public interface IContestCategoriesRepository
    {
        Task<ContestCategory> Get(int id);
        Task<List<ContestCategory>> GetAll();
        Task<List<ContestCategory>> Find(Func<ContestCategory, bool> predicate);
        Task Save(ContestCategory contestRange);
        Task Remove(int id);
    }
}
