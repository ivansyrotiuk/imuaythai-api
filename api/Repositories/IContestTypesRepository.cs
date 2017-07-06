using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IContestTypesRepository
    {
        ContestType Get(int id);
        IEnumerable<ContestType> GetAll();
        IEnumerable<ContestType> Find(Func<ContestType, bool> predicate);
        void Save(ContestType contestType);
        void Remove(int id);
    }
}
