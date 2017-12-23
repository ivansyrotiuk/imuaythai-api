using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Dictionaries
{
    public interface IKhanLevelsRepository
    {
        Task<KhanLevel> Get(int id);
        Task<List<KhanLevel>> GetAll();
        Task<List<KhanLevel>> Find(Func<KhanLevel, bool> predicate);
        Task Save(KhanLevel level);
        Task Remove(int id);
    }
}
