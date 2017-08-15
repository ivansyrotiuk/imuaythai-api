using MuaythaiSportManagementSystemApi.Contests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IContestRingsRepository
    {
        Task SaveCategoryRings(int contestId, List<ContestRingDto> rings);
    }
}
