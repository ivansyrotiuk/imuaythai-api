using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Data;
using Microsoft.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Dictionaries;
using MuaythaiSportManagementSystemApi.Contests;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public class ContestRepository : IContestRepository
    {
        private readonly ApplicationDbContext _context;

        public ContestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Contest>> Find(Func<Contest, bool> predicate)
        {
            var contests = _context.Contests.Where(predicate).AsQueryable();
            return contests.ToListAsync();
        }

        public Task<Contest> Get(int id)
        {
            return _context.Contests.Include(c => c.Country).Include(c => c.Institution).Include(c => c.ContestCategoriesMappings).ThenInclude(c => c.ContestCategory).Include(c => c.Rings).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<List<Contest>> GetAll()
        {
            return _context.Contests.ToListAsync();
        }

        public Task Remove(int id)
        {
            var contest = _context.Contests.FirstOrDefault(i => i.Id == id);
            _context.Contests.Remove(contest);
            return _context.SaveChangesAsync();
        }

        public Task Save(Contest contest)
        {
            if (contest.Id == 0)
            {
                _context.Contests.Add(contest);
            }

            return _context.SaveChangesAsync();
        }

        public Task SaveCategoryMappings(Contest contest, List<ContestCategoryDto> mappings)
        {
            _context.ContestCategoriesMappings.RemoveRange(_context.ContestCategoriesMappings.Where(m => m.ContestId == contest.Id));

            var contestCategoryMappings = mappings.Select(m => new ContestCategoriesMapping
            {
                ContestCategoryId = m.Id,
                ContestId = contest.Id
            }).ToList();

            _context.ContestCategoriesMappings.AddRange(contestCategoryMappings);
            return _context.SaveChangesAsync();
        }

        public Task SaveCategoryRings(Contest contest, List<ContestRingDto> rings)
        {
            rings.ForEach(ring =>
            {
                ring.ContestId = contest.Id;
                ring.ContestDay = ring.ContestDay.Date.ToUniversalTime();
                ring.RingsAvilability.ForEach(item =>
                {
                    item.From = item.From.AddSeconds(-item.From.Second);
                    item.To = item.To.AddSeconds(-item.To.Second);
                });
            });

            var ringEntities = rings.SelectMany(ring => ring.RingsAvilability.Select(item => new ContestRing
            {
                ContestId = ring.ContestId,
                Name = item.Name,
                From = item.From,
                To = item.To,
            })).ToList();

            _context.ContestRings.RemoveRange(_context.ContestRings.Where(r => r.ContestId == contest.Id));
            _context.ContestRings.AddRange(ringEntities);
            return _context.SaveChangesAsync();
        }
    }
}
