using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Fights;

namespace IMuaythai.Fights
{
    public interface IFightsService
    {
        Task<FightModel> GetFight(int id);
        Task<List<FightModel>> GetFights(int contestId);
        Task<List<FightModel>> GetFights(int contestId, int categoryId);
        Task<List<FightModel>> BuildFights(int contestId);
        Task<List<FightModel>> BuildFights(int contestId, int categoryId);
        Task<List<FightModel>> ScheduleFights(int contestId);
        Task<List<FightModel>> MoveFighter(FighterMoving fighterMoving);
        Task<List<FightModel>> MoveFight(FightMoving fighterMoving);
        Task<List<FightModel>> TossupJudges(int contestId);
        Task<List<FightModel>> Save(List<Fight> fights);
        Task ClearContestJudgeMappings(int contestId);
    }
}