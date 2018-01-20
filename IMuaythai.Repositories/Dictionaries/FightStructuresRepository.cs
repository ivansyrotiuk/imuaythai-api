using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories.Dictionaries
{
    public class FightStructuresRepository : IFightStructuresRepository
    {
        private readonly ApplicationDbContext _context;

        public FightStructuresRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<FightStructure> Get(int id)
        {
            return _context.FightStructures
                .Include(f => f.WeightAgeCategory)
                .Include(f => f.Round)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<FightStructure>> GetAll()
        {
            return _context.FightStructures
                .Include(f => f.WeightAgeCategory)
                .Include(f => f.Round)
                .ToListAsync();
        }

        public Task<List<FightStructure>> Find(Func<FightStructure, bool> predicate)
        {
            return _context.FightStructures
                .Include(f => f.WeightAgeCategory)
                .Include(f => f.Round)
                .Where(predicate).AsQueryable().ToListAsync();
        }

        public Task Save(FightStructure structure)
        {
            if (structure.Id == 0)
            {
                _context.FightStructures.Add(structure);
            }
            else
            {
                _context.Entry(structure).State = EntityState.Modified;
            }

            return _context.SaveChangesAsync();
        }

        public Task Remove(int id)
        {
            var structure = _context.FightStructures.FirstOrDefault(i => i.Id == id);
            _context.FightStructures.Remove(structure);
            return _context.SaveChangesAsync();
        }
    }
}