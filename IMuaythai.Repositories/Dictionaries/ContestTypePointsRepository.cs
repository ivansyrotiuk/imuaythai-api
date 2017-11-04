using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Data;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories.Dictionaries
{
    public class ContestTypePointsRepository : IContestTypePointsRepository
    {
        private readonly ApplicationDbContext _context;

        public ContestTypePointsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<ContestTypePoints> Get(int id)
        {
            return _context.ContestTypePoints
                .Include(p=>p.ContestType)
                .Include(p => p.ContestRange).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<ContestTypePoints>> GetAll()
        {
            return _context.ContestTypePoints
                .Include(p => p.ContestType)
                .Include(p => p.ContestRange).ToListAsync();
        }

        public Task<List<ContestTypePoints>> Find(Func<ContestTypePoints, bool> predicate)
        {
            return _context.ContestTypePoints.Where(predicate).AsQueryable().ToListAsync();
        }

        public Task Save(ContestTypePoints points)
        {
            if (points.Id == 0)
            {
                _context.ContestTypePoints.Add(points);
            }

            return _context.SaveChangesAsync();
        }

        public Task Remove(int id)
        {
            var points = _context.ContestTypePoints.FirstOrDefault(i => i.Id == id);
            _context.ContestTypePoints.Remove(points);
            return _context.SaveChangesAsync();
        }
    }
}
