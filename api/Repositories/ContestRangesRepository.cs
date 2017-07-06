using System;
using System.Collections.Generic;
using System.Linq;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public class ContestRangesRepository : IContestRangesRepository
    {
        private readonly ApplicationDbContext _context;

        public ContestRangesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ContestRange Get(int id)
        {
            return _context.ContestRanges.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<ContestRange> GetAll()
        {
            return _context.ContestRanges;
        }

        public IEnumerable<ContestRange> Find(Func<ContestRange, bool> predicate)
        {
            return _context.ContestRanges.Where(predicate);
        }

        public void Save(ContestRange contestRange)
        {
            if (contestRange.Id == 0)
            {
                _context.ContestRanges.Add(contestRange);
            }

            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var contestRange = _context.ContestRanges.FirstOrDefault(i => i.Id == id);
            _context.ContestRanges.Remove(contestRange);
            _context.SaveChanges();
        }
    }
}