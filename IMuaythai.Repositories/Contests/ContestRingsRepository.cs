using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Data;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories.Contests
{
    public class ContestRingsRepository: IContestRingsRepository
    {
        private readonly ApplicationDbContext _context;

        public ContestRingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<ContestRing>> GetByContest(int contestId)
        {
            return _context.ContestRings.Where(ring => ring.ContestId == contestId).ToListAsync();
        }

        public Task SaveCategoryRings(int contestId, List<ContestRingDto> rings)
        {
            rings.ForEach(ring =>
            {
                ring.ContestId = contestId;
                ring.ContestDay = ring.ContestDay.Date.ToUniversalTime();
                ring.RingsAvilability.ForEach(item =>
                {
                    item.From = item.From.AddSeconds(-item.From.Second);
                    item.To = item.To.AddSeconds(-item.To.Second);
                });
            });

            var ringEntities = rings.SelectMany(ring => ring.RingsAvilability.Select(item => new ContestRing
            {
                ContestId = ring.ContestId,
                Name = item.Name,
                From = item.From,
                To = item.To,
            })).ToList();

            _context.ContestRings.RemoveRange(_context.ContestRings.Where(r => r.ContestId == contestId));
            _context.ContestRings.AddRange(ringEntities);
            return _context.SaveChangesAsync();
        }
    }
}
