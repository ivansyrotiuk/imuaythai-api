using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Fights;

namespace IMuaythai.Fights
{
    public interface IFightsService
    {
        Task<FightResponseModel> GetFight(int id);
        Task<List<FightResponseModel>> GetFights(int contestId);
        Task<List<FightResponseModel>> GetFights(int contestId, int categoryId);
        Task<List<FightResponseModel>> BuildFights(int contestId);
        Task<List<FightResponseModel>> BuildFights(int contestId, int categoryId);
        Task<List<FightResponseModel>> ScheduleFights(int contestId);
        Task<List<FightResponseModel>> MoveFighter(FighterMoving fighterMoving);
        Task<List<FightResponseModel>> MoveFight(FightMoving fighterMoving);
        Task<List<FightResponseModel>> TossupJudges(int contestId);
        Task<List<FightResponseModel>> Save(List<Fight> fights);
        Task ClearContestJudgeMappings(int contestId);
    }
}