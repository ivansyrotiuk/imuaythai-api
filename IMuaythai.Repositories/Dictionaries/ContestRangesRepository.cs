using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories.Dictionaries
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
            return _context.ContestRanges.Where(contestRange => !contestRange.Deleted).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<ContestRange>> GetAll()
        {
            return _context.ContestRanges.Where(contestRange => !contestRange.Deleted).ToListAsync();
        }

        public Task<List<ContestRange>> Find(Func<ContestRange, bool> predicate)
        {
            return _context.ContestRanges.Where(predicate).Where(contestRange => !contestRange.Deleted).AsQueryable().ToListAsync();
        }

        public Task Save(ContestRange contestRange)
        {
            if (contestRange.Id == 0)
            {
                _context.ContestRanges.Add(contestRange);
            }
            else
            {
                _context.Entry(contestRange).State = EntityState.Modified;
            }

            return _context.SaveChangesAsync();
        }

        public Task Remove(int id)
        {
            var contestRange = _context.ContestRanges.FirstOrDefault(i => i.Id == id);
            if (contestRange == null)
            {
                throw new Exception($"ContestRange with id={id} is not found");
            }

            contestRange.Deleted = true;
            return _context.SaveChangesAsync();
        }
    }
}