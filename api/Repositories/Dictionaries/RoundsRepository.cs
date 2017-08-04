using System;
using System.Collections.Generic;
using System.Linq;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public class RoundsRepository : IRoundsRepository
    {
        private readonly ApplicationDbContext _context;

        public RoundsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<Round> Get(int id)
        {
            return _context.Rounds.FirstOrDefaultAsync(r => r.Id == id);
        }

        public Task<List<Round>> GetAll()
        {
            return _context.Rounds.ToListAsync();
        }

        public Task<List<Round>> Find(Func<Round, bool> predicate)
        {
            return _context.Rounds.Where(predicate).AsQueryable().ToListAsync();
        }

        public Task Save(Round round)
        {
            if (round.Id == 0)
            {
                _context.Rounds.Add(round);
            }

            return _context.SaveChangesAsync();
        }

        public Task Remove(int id)
        {
            var round = _context.Rounds.FirstOrDefault(r => r.Id == id);
            _context.Rounds.Remove(round);
            return _context.SaveChangesAsync();
        }
    }
}