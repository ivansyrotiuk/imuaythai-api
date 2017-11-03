using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Dictionaries
{
    public interface IContestTypesRepository
    {
        Task<ContestType> Get(int id);
        Task<List<ContestType>> GetAll();
        Task<List<ContestType>> Find(Func<ContestType, bool> predicate);
        Task Save(ContestType contestType);
        Task Remove(int id);
    }
}
