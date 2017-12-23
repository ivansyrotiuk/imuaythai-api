using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Contests;

namespace IMuaythai.Repositories.Contests
{
    public interface IContestRingsRepository
    {
        Task<List<ContestRing>> GetByContest(int contestId);
        Task SaveCategoryRings(int contestId, List<ContestRingModel> rings);
    }
}
