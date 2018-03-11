using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;
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
                .Where(contestTypePoints => !contestTypePoints.Deleted)
                .Include(p=>p.ContestType)
                .Include(p => p.ContestRange).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<ContestTypePoints>> GetAll()
        {
            return _context.ContestTypePoints
                .Where(contestTypePoints => !contestTypePoints.Deleted)
                .Include(p => p.ContestType)
                .Include(p => p.ContestRange).ToListAsync();
        }

        public Task<List<ContestTypePoints>> Find(Func<ContestTypePoints, bool> predicate)
        {
            return _context.ContestTypePoints.Where(predicate).Where(contestTypePoints => !contestTypePoints.Deleted).AsQueryable().ToListAsync();
        }

        public Task Save(ContestTypePoints points)
        {
            if (points.Id == 0)
            {
                _context.ContestTypePoints.Add(points);
            }
            else
            {
                _context.Entry(points).State = EntityState.Modified;
            }

            return _context.SaveChangesAsync();
        }

        public Task Remove(int id)
        {
            var points = _context.ContestTypePoints.FirstOrDefault(i => i.Id == id);
            if (points == null)
            {
                throw new Exception($"ContestTypePoints with id={id} is not found");
            }

            points.Deleted = true;
            return _context.SaveChangesAsync();
        }
    }
}
