using System;
using System.Collections.Generic;
using System.Linq;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public class ContestTypesRepository : IContestTypesRepository
    {
        private readonly ApplicationDbContext _context;

        public ContestTypesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ContestType Get(int id)
        {
            return _context.ContestTypes.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<ContestType> GetAll()
        {
            return _context.ContestTypes.ToListAsync().Result; 
        }

        public IEnumerable<ContestType> Find(Func<ContestType, bool> predicate)
        {
            return _context.ContestTypes.Where(predicate);
        }

        public void Save(ContestType contestType)
        {
            if (contestType.Id == 0)
            {
                _context.ContestTypes.Add(contestType);
            }

            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var contestType = _context.ContestTypes.FirstOrDefault(i => i.Id == id);
            _context.ContestTypes.Remove(contestType);
            _context.SaveChanges();
        }
    }
}
