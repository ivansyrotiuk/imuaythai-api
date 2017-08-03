using System;
using System.Collections.Generic;
using System.Linq;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
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
            return _context.FightStructures.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<FightStructure>> GetAll()
        {
            return _context.FightStructures.ToListAsync();
        }

        public Task<List<FightStructure>> Find(Func<FightStructure, bool> predicate)
        {
            return _context.FightStructures.Where(predicate).AsQueryable().ToListAsync();
        }

        public Task Save(FightStructure structure)
        {
            if (structure.Id == 0)
            {
                _context.FightStructures.Add(structure);
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