using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.Models.Dashboard;

namespace IMuaythai.Dashboard
{
    public interface IContestEventsService
    {
        Task<IEnumerable<ContestEvent>> GetContestEvents();
    }
}