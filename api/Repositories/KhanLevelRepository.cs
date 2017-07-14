using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public class KhanLevelRepository : IKhanLevelsRepository
    {
        private readonly ApplicationDbContext _context;

        public KhanLevelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<KhanLevel> Find(Func<KhanLevel, bool> predicate)
        {
            return _context.KhanLevels.Where(predicate);
        }

        public KhanLevel Get(int id)
        {
            return _context.KhanLevels.FirstOrDefault(i=>i.Id == id);
        }

        public IEnumerable<KhanLevel> GetAll()
        {
            return _context.KhanLevels;
        }

        public void Remove(int id)
        {
            var level = _context.KhanLevels.FirstOrDefault(i => i.Id == id);
            _context.KhanLevels.Remove(level);
            _context.SaveChanges();
        }

        public void Save(KhanLevel level)
        {
            if (level.Id == 0)
            {
                _context.KhanLevels.Add(level);
            }

            _context.SaveChanges();
        }
    }
}
