using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories.Dictionaries
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
            return _context.Rounds.Where(round => !round.Deleted).FirstOrDefaultAsync(r => r.Id == id);
        }

        public Task<List<Round>> GetAll()
        {
            return _context.Rounds.Where(round => !round.Deleted).ToListAsync();
        }

        public Task<List<Round>> Find(Func<Round, bool> predicate)
        {
            return _context.Rounds.Where(predicate).Where(round => !round.Deleted).AsQueryable().ToListAsync();
        }

        public Task Save(Round round)
        {
            if (round.Id == 0)
            {
                _context.Rounds.Add(round);
            }
            else
            {
                _context.Entry(round).State = EntityState.Modified;
            }

            return _context.SaveChangesAsync();
        }

        public Task Remove(int id)
        {
            var round = _context.Rounds.FirstOrDefault(r => r.Id == id);
            if (round == null)
            {
                throw new Exception($"Round with id={id} is not found");
            }

            round.Deleted = true;
            return _context.SaveChangesAsync();
        }
    }
}