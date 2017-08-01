using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Data;
using Microsoft.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Dictionaries;

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
            return _context.Contests.Include(c => c.Country).Include(c => c.Institution).Include(c => c.ContestCategoriesMappings).ThenInclude(c => c.ContestCategory).FirstOrDefaultAsync(i => i.Id == id);
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
    }
}
