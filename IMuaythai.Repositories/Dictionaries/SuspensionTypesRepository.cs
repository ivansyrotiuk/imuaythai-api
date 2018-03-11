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
            var types = _context.SuspensionTypes.Where(predicate).Where(suspensionType => !suspensionType.Deleted).AsQueryable();
            return types.ToListAsync();
        }

        public Task<SuspensionType> Get(int id)
        {
            return _context.SuspensionTypes.Where(suspensionType => !suspensionType.Deleted).FirstOrDefaultAsync(i=>i.Id == id);
        }

        public Task<List<SuspensionType>> GetAll()
        {
            return _context.SuspensionTypes.Where(suspensionType => !suspensionType.Deleted).ToListAsync();
        }

        public Task Remove(int id)
        {
            var type = _context.SuspensionTypes.FirstOrDefault(i => i.Id == id);
            if (type == null)
            {
                throw new Exception($"SuspensionType with id={id} is not found");
            }

            type.Deleted = true;
            return _context.SaveChangesAsync();
        }

        public Task Save(SuspensionType type)
        {
            if (type.Id == 0)
            {
                _context.SuspensionTypes.Add(type);
            }
            else
            {
                _context.Entry(type).State = EntityState.Modified;
            }

            return _context.SaveChangesAsync();
        }
    }
}
