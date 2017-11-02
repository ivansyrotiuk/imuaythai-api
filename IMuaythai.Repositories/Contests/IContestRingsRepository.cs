using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Contests
{
    public interface IContestRingsRepository
    {
        Task<List<ContestRing>> GetByContest(int contestId);
        Task SaveCategoryRings(int contestId, List<ContestRingDto> rings);
    }
}
