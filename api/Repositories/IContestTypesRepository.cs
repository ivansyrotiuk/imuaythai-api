using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Repositories
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
