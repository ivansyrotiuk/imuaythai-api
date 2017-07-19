using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface ISuspensionTypesRepository
    {
        SuspensionType Get(int id);
        IEnumerable<SuspensionType> GetAll();
        IEnumerable<SuspensionType> Find(Func<SuspensionType, bool> predicate);
        void Save(SuspensionType institution);
        void Remove(int id);
    }
}
