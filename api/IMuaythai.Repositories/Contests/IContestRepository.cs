using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Contests
{
    public interface IContestRepository
    {
        Task<Contest> Get(int id);
        Task<List<Contest>> GetAll();
        Task<List<Contest>> Find(Func<Contest, bool> predicate);
        Task Save(Contest contest);
        Task Remove(int id);
    }
}
