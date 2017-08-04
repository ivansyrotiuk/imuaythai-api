using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IFightStructuresRepository
    {
        Task<FightStructure> Get(int id);
        Task<List<FightStructure>> GetAll();
        Task<List<FightStructure>> Find(Func<FightStructure, bool> predicate);
        Task Save(FightStructure structure);
        Task Remove(int id);
    }
}
