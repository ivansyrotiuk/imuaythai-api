using MuaythaiSportManagementSystemApi.Contests;
using MuaythaiSportManagementSystemApi.Dictionaries;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IContestRepository
    {
        Task<Contest> Get(int id);
        Task<List<Contest>> GetAll();
        Task<List<Contest>> Find(Func<Contest, bool> predicate);
        Task Save(Contest contest);
        Task SaveCategoryMappings(Contest contest, List<ContestCategoryDto> contestCategoriesMappings);
        Task SaveCategoryRings(Contest contest, List<ContestRingDto> rings);
        Task Remove(int id);
    }
}
