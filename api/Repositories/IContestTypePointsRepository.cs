using System;
using System.Collections.Generic;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IContestTypePointsRepository
    {
        ContestTypePoints Get(int id);
        IEnumerable<ContestTypePoints> GetAll();
        IEnumerable<ContestTypePoints> Find(Func<ContestTypePoints, bool> predicate);
        void Save(ContestTypePoints contestType);
        void Remove(int id);
    }
}
