using System;
using System.Collections.Generic;
using MuaythaiSportManagementSystemApi.Models;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IContestTypePointsRepository
    {
        Task<ContestTypePoints>Get(int id);
        Task<List<ContestTypePoints>> GetAll();
        Task<List<ContestTypePoints>> Find(Func<ContestTypePoints, bool> predicate);
        Task Save(ContestTypePoints contestType);
        Task Remove(int id);
    }
}
