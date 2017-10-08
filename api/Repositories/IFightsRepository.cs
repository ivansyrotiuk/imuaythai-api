using Microsoft.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IFightsRepository
    {
        Task<Fight> Get(int id);
        Task<List<Fight>> GetFights(int contestId);
        Task<List<Fight>> GetFights(int contestId, int contestCategoryId);
        Task SaveFights(List<Fight> fights);
        Task RemoveByContestCategory(int contestId, int categoryId);
        Task ClearJudgeMappings(List<Fight> fights);
    }

    public class FightsRepository : IFightsRepository
    {
        private ApplicationDbContext _context;

        public FightsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Fight> Get(int id)
        {
            return _context.Fights
                .Include(f => f.BlueAthlete).ThenInclude(f => f.Country)
                .Include(f => f.BlueAthlete).ThenInclude(f => f.Institution)
                .Include(f => f.BlueAthlete).ThenInclude(f => f.KhanLevel)
                .Include(f => f.RedAthlete).ThenInclude(f => f.Country)
                .Include(f => f.RedAthlete).ThenInclude(f => f.Institution)
                .Include(f => f.RedAthlete).ThenInclude(f => f.KhanLevel)
                .Include(f => f.Referee)
                .Include(f => f.Structure).ThenInclude(s => s.WeightAgeCategory)
                .Include(f => f.Structure).ThenInclude(s => s.Round)
                .Include(f => f.TimeKeeper)
                .Include(f => f.FightJudgesMappings).ThenInclude(j => j.Judge)
                .Include(f => f.FightPoints).ThenInclude(p => p.Judge)
                .Include(f => f.Contest)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public Task<List<Fight>> GetFights(int contestId)
        {
            return _context.Fights
                .Where(f => f.ContestId == contestId)
                .Include(f => f.BlueAthlete).ThenInclude(f => f.Country)
                .Include(f => f.BlueAthlete).ThenInclude(f => f.Institution)
                .Include(f => f.RedAthlete).ThenInclude(f => f.Country)
                .Include(f => f.RedAthlete).ThenInclude(f => f.Institution)

                .ToListAsync();
        }

        public Task<List<Fight>> GetFights(int contestId, int contestCategoryId)
        {
            return _context.Fights
                .Where(f => f.ContestId == contestId && f.ContestCategoryId == contestCategoryId)
                .Include(f => f.BlueAthlete).ThenInclude(f => f.Country)
                .Include(f => f.BlueAthlete).ThenInclude(f => f.Institution)
                .Include(f => f.RedAthlete).ThenInclude(f => f.Country)
                .Include(f => f.RedAthlete).ThenInclude(f => f.Institution)

                .ToListAsync();
        }

        public Task RemoveByContestCategory(int contestId, int categoryId)
        {
            _context.Fights.RemoveRange(_context.Fights.Where(f => f.ContestId == contestId && f.ContestCategoryId == categoryId));
            return _context.SaveChangesAsync();
        }

        public Task SaveFights(List<Fight> fights)
        {
            var newFights = fights.Where(f => f.Id == 0).ToList();
            var existedFights = fights.Where(f => f.Id != 0).ToList();

            _context.AddRange(newFights);
            _context.AttachRange(existedFights);

            return _context.SaveChangesAsync();
        }

        public async Task ClearJudgeMappings(List<Fight> fights)
        {
            var fightIds = fights.Select(fight => fight.Id).ToList();
            _context.FightJudgesMappings.RemoveRange(_context.FightJudgesMappings.Where(mapping => fightIds.Contains(mapping.FightId)));
            await _context.SaveChangesAsync();
        }
    }
}
