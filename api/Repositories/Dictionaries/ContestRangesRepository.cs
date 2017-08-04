using System;
using System.Collections.Generic;
using System.Linq;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public class ContestRangesRepository : IContestRangesRepository
    {
        private readonly ApplicationDbContext _context;

        public ContestRangesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<ContestRange> Get(int id)
        {
            return _context.ContestRanges.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<ContestRange>> GetAll()
        {
            return _context.ContestRanges.ToListAsync();
        }

        public Task<List<ContestRange>> Find(Func<ContestRange, bool> predicate)
        {
            return _context.ContestRanges.Where(predicate).AsQueryable().ToListAsync();
        }

        public Task Save(ContestRange contestRange)
        {
            if (contestRange.Id == 0)
            {
                _context.ContestRanges.Add(contestRange);
            }

            return _context.SaveChangesAsync();
        }

        public Task Remove(int id)
        {
            var contestRange = _context.ContestRanges.FirstOrDefault(i => i.Id == id);
            _context.ContestRanges.Remove(contestRange);
            return _context.SaveChangesAsync();
        }
    }
}