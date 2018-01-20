using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories.Dictionaries
{
    public class SuspensionTypesRepository : ISuspensionTypesRepository
    {
        private readonly ApplicationDbContext _context;

        public SuspensionTypesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<SuspensionType>> Find(Func<SuspensionType, bool> predicate)
        {
            var types = _context.SuspensionTypes.Where(predicate).AsQueryable();
            return types.ToListAsync();
        }

        public Task<SuspensionType> Get(int id)
        {
            return _context.SuspensionTypes.FirstOrDefaultAsync(i=>i.Id == id);
        }

        public Task<List<SuspensionType>> GetAll()
        {
            return _context.SuspensionTypes.ToListAsync();
        }

        public Task Remove(int id)
        {
            var type = _context.SuspensionTypes.FirstOrDefault(i => i.Id == id);
            _context.SuspensionTypes.Remove(type);
            return _context.SaveChangesAsync();
        }

        public Task Save(SuspensionType type)
        {
            if (type.Id == 0)
            {
                _context.SuspensionTypes.Add(type);
            }

            return _context.SaveChangesAsync();
        }
    }
}
