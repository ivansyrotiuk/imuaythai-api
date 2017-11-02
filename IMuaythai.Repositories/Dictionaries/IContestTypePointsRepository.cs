using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Dictionaries
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
