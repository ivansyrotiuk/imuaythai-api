using MuaythaiSportManagementSystemApi.Dictionaries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IContestCategoryMappingsRepository
    {
        Task SaveCategoryMappings(int contestId, List<ContestCategoryDto> contestCategoriesMappings);
    }
}
