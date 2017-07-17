using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IKhanLevelsRepository
    {
        KhanLevel Get(int id);
        IEnumerable<KhanLevel> GetAll();
        IEnumerable<KhanLevel> Find(Func<KhanLevel, bool> predicate);
        void Save(KhanLevel institution);
        void Remove(int id);
    }
}
