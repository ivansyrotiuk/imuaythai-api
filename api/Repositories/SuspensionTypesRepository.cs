using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public class SuspensionTypesRepository : ISuspensionTypesRepository
    {
        private readonly ApplicationDbContext _context;

        public SuspensionTypesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SuspensionType> Find(Func<SuspensionType, bool> predicate)
        {
            return _context.SuspensionTypes.Where(predicate);
        }

        public SuspensionType Get(int id)
        {
            return _context.SuspensionTypes.FirstOrDefault(i=>i.Id == id);
        }

        public IEnumerable<SuspensionType> GetAll()
        {
            return _context.SuspensionTypes;
        }

        public void Remove(int id)
        {
            var type = _context.SuspensionTypes.FirstOrDefault(i => i.Id == id);
            _context.SuspensionTypes.Remove(type);
            _context.SaveChanges();
        }

        public void Save(SuspensionType type)
        {
            if (type.Id == 0)
            {
                _context.SuspensionTypes.Add(type);
            }

            _context.SaveChanges();
        }
    }
}
