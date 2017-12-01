using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.Models.Dictionaries;

namespace IMuaythai.Dictionaries
{
    public interface IContestTypePointsService
    {
        Task<IEnumerable<ContestPointsModel>> GetAllContestTypePoints();
        Task<ContestPointsModel> GetContestTypePoints(int id);
        Task<ContestPointsModel> SaveContestTypePoints(ContestPointsModel contestPointsModel);
        Task RemoveContestTypePoints(int id);
    }
}