using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Fights
{
    public interface IFightsService
    {
        Task<Fight> GetFight(int id);
        Task<List<Fight>> GetFights(int contestId);
        Task<List<Fight>> GetFights(int contestId, int categoryId);
        Task<List<Fight>> BuildFights(int contestId);
        Task<List<Fight>> BuildFights(int contestId, int categoryId);
        Task<List<Fight>> ScheduleFights(int contestId);
        Task<List<Fight>> MoveFighter(FighterMoving fighterMoving);
        Task<List<Fight>> MoveFight(FightMoving fighterMoving);
        Task<List<Fight>> TossupJudges(int contestId);
        Task<List<Fight>> Save(List<Fight> fights);
        Task ClearContestJudgeMappings(int contestId);
    }
}