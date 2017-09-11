using MuaythaiSportManagementSystemApi.Contests;
using MuaythaiSportManagementSystemApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IContestRingsRepository
    {
        Task<List<ContestRing>> GetByContest(int contestId);
        Task SaveCategoryRings(int contestId, List<ContestRingDto> rings);
    }
}
