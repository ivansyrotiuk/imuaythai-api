using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.Models.Contests;

namespace IMuaythai.Contests
{
    public interface IContestRequestsService
    {
        Task<List<ContestRequestModel>> GetRequests(int contestId);
        Task<List<ContestRequestModel>> GetJudgeRequests(int contestId);
        Task<List<ContestRequestModel>> GetInstitutionRequests(int contestId, int institutionId);
        Task<List<ContestRequestModel>> GetUserRequests(int contestId, string userId);
        Task<ContestCandidatesModel> GetCandidates(int institutionId);
        Task<ContestRequestModel> AcceptRequest(int requestId, string acceptedByUser);
        Task<ContestRequestModel> RejectRequest(int requestId, string acceptedByUser);
        Task<ContestRequestModel> SaveRequest(ContestRequestModel request);
        Task RemoveRequest(int requestId);
    }
}
