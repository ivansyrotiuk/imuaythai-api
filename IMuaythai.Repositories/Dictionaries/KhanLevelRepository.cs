using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Data;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories.Dictionaries
{
    public class KhanLevelRepository : IKhanLevelsRepository
    {
        private readonly ApplicationDbContext _context;

        public KhanLevelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<KhanLevel>> Find(Func<KhanLevel, bool> predicate)
        {
            return _context.KhanLevels.Where(predicate).AsQueryable().ToListAsync();
        }

        public Task<KhanLevel> Get(int id)
        {
            return _context.KhanLevels.FirstOrDefaultAsync(i=>i.Id == id);
        }

        public Task<List<KhanLevel>> GetAll()
        {
            return _context.KhanLevels.ToListAsync();
        }

        public Task Remove(int id)
        {
            var level = _context.KhanLevels.FirstOrDefault(i => i.Id == id);
            _context.KhanLevels.Remove(level);
            return _context.SaveChangesAsync();
        }

        public Task Save(KhanLevel level)
        {
            if (level.Id == 0)
            {
                _context.KhanLevels.Add(level);
            }

            return _context.SaveChangesAsync();
        }
    }
}
