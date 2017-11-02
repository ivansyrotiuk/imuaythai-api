using System;
using System.Collections.Generic;
using System.Linq;
using MuaythaiSportManagementSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Data;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public class ContestCategoriesRepository : IContestCategoriesRepository
    {
        private readonly ApplicationDbContext _context;

        public ContestCategoriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<ContestCategory> Get(int id)
        {
            return _context.ContestCategories
                .Include(c => c.ContestTypePoints).ThenInclude(p => p.ContestType)
                .Include(c => c.ContestTypePoints).ThenInclude(p => p.ContestRange)
                .Include(c => c.FightStructure).ThenInclude(f => f.WeightAgeCategory)
                .Include(c => c.FightStructure).ThenInclude(f => f.Round)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<ContestCategory>> GetAll()
        {
            return _context.ContestCategories
                .Include(c => c.ContestTypePoints).ThenInclude(p => p.ContestType)
                .Include(c => c.ContestTypePoints).ThenInclude(p => p.ContestRange)
                .Include(c => c.FightStructure).ThenInclude(f=>f.WeightAgeCategory)
                .Include(c => c.FightStructure).ThenInclude(f => f.Round)
                .ToListAsync();
        }

        public Task<List<ContestCategory>> Find(Func<ContestCategory, bool> predicate)
        {
            return _context.ContestCategories
                .Include(c => c.ContestTypePoints).ThenInclude(p => p.ContestType)
                .Include(c => c.ContestTypePoints).ThenInclude(p => p.ContestRange)
                .Include(c => c.FightStructure).ThenInclude(f => f.WeightAgeCategory)
                .Include(c => c.FightStructure).ThenInclude(f => f.Round)
                .Where(predicate).AsQueryable().ToListAsync();
        }

        public Task Save(ContestCategory contestCategory)
        {
            if (contestCategory.Id == 0)
            {
                _context.ContestCategories.Add(contestCategory);
            }

            return _context.SaveChangesAsync();
        }

        public Task Remove(int id)
        {
            var contestCategory = _context.ContestCategories.FirstOrDefault(i => i.Id == id);
            _context.ContestCategories.Remove(contestCategory);
            return _context.SaveChangesAsync();
        }
    }
}