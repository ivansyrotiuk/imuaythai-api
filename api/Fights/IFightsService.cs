using System.Collections.Generic;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Fights
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
    }
}