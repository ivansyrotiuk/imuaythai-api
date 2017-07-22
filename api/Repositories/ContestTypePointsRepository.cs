using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Data;
using Microsoft.EntityFrameworkCore;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public class ContestTypePointsRepository : IContestTypePointsRepository
    {
        private readonly ApplicationDbContext _context;

        public ContestTypePointsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ContestTypePoints Get(int id)
        {
            return _context.ContestTypePoints.ToListAsync().Result.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<ContestTypePoints> GetAll()
        {
            return _context.ContestTypePoints;
        }

        public IEnumerable<ContestTypePoints> Find(Func<ContestTypePoints, bool> predicate)
        {
            return _context.ContestTypePoints.Where(predicate);
        }

        public void Save(ContestTypePoints points)
        {
            if (points.Id == 0)
            {
                _context.ContestTypePoints.Add(points);
            }

            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var points = _context.ContestTypePoints.FirstOrDefault(i => i.Id == id);
            _context.ContestTypePoints.Remove(points);
            _context.SaveChanges();
        }
    }
}
