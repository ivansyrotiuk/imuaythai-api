using Microsoft.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IContestRequestRepository
    {
        Task<ContestRequest> Get(int id);
        Task<List<ContestRequest>> GetByContest(int contestId);
        Task<List<ContestRequest>> GetAll();
        Task<List<ContestRequest>> Find(Expression<Func<ContestRequest, bool>> predicate);
        Task Save(ContestRequest request);
        Task Remove(ContestRequest request);
    }

    public class ContestRequestRepository : IContestRequestRepository
    {
        private ApplicationDbContext _context;

        public ContestRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<ContestRequest>> Find(Expression<Func<ContestRequest, bool>> predicate)
        {
            return _context.ContestRequests.Include(c => c.User).ThenInclude(u => u.Country)
                .Include(c => c.ContestCategory)
                .Include(c => c.AcceptedByUser).Include(c => c.Institution).Where(predicate).ToListAsync();
        }

        public Task<ContestRequest> Get(int id)
        {
            return _context.ContestRequests.Include(c => c.User).ThenInclude(u => u.Country)
                .Include(c => c.ContestCategory)
                .Include(c => c.AcceptedByUser).Include(c => c.Institution).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<ContestRequest>> GetAll()
        {
            return _context.ContestRequests.ToListAsync();
        }

        public Task<List<ContestRequest>> GetByContest(int contestId)
        {
            return _context.ContestRequests.Where(r => r.ContestId == contestId).Include(c => c.User).ThenInclude(u => u.Country)
                .Include(c => c.ContestCategory)
                .Include(c => c.AcceptedByUser).Include(c => c.Institution).ToListAsync();
        }

        public Task Remove(ContestRequest request)
        {
            _context.ContestRequests.Remove(request);
            return _context.SaveChangesAsync();
        }

        public Task Save(ContestRequest request)
        {
            if (request.Id == 0)
            {
                _context.ContestRequests.Add(request);
            }
            else
            {
                _context.ContestRequests.Attach(request);
            }

            return _context.SaveChangesAsync();
        }
    }
}
