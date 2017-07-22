using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IKhanLevelsRepository
    {
        Task<KhanLevel> Get(int id);
        Task<List<KhanLevel>> GetAll();
        Task<List<KhanLevel>> Find(Func<KhanLevel, bool> predicate);
        Task Save(KhanLevel institution);
        Task Remove(int id);
    }
}
