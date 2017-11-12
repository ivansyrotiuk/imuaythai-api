using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Dictionaries
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
