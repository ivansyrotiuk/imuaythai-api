using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface ISuspensionTypesRepository
    {
        Task<SuspensionType> Get(int id);
        Task<List<SuspensionType>> GetAll();
        Task<List<SuspensionType>> Find(Func<SuspensionType, bool> predicate);
        Task Save(SuspensionType type);
        Task Remove(int id);
    }
}
