using MuaythaiSportManagementSystemApi.Dictionaries;
using MuaythaiSportManagementSystemApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IContestCategoryMappingsRepository
    {
        Task<List<ContestCategoriesMapping>> GetByContest(int contestId);
        Task SaveCategoryMappings(int contestId, List<ContestCategoryDto> contestCategoriesMappings);
    }
}
