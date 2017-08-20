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
        Task<List<ContestRequest>> GetByInstitution(int contestId, int institutionId);
        Task<List<ContestRequest>> GetByUnassociatedUser(int contestId, string userId);
        Task<List<ContestRequest>> GetContestAcceptedFighterRequests(int contestId);
        Task<List<ContestRequest>> GetContestAcceptedFighterRequests(int contestId, int categoryId);
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
            return _context.ContestRequests.Where(predicate).ToListAsync();
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

        public Task<List<ContestRequest>> GetByInstitution(int contestId, int institutionId)
        {
            return _context.ContestRequests.Where(r => r.ContestId == contestId && r.InstitutionId == institutionId).Include(c => c.User).ThenInclude(u => u.Country)
                .Include(c => c.ContestCategory)
                .Include(c => c.AcceptedByUser).Include(c => c.Institution).ToListAsync();
        }

        public Task<List<ContestRequest>> GetByUnassociatedUser(int contestId, string userId)
        {
            return _context.ContestRequests.Where(r => r.ContestId == contestId && r.InstitutionId == null && r.UserId == userId)
               .Include(c => c.User).ThenInclude(u => u.Country)
               .Include(c => c.ContestCategory)
               .Include(c => c.AcceptedByUser).Include(c => c.Institution).ToListAsync();
        }

        public Task<List<ContestRequest>> GetContestAcceptedFighterRequests(int contestId)
        {
            return _context.ContestRequests.Where(m => m.ContestId == contestId &&
                                                       m.Type == ContestRoleType.Fighter &&
                                                       m.Status == ContestRoleRequestStatus.Accepted)
                .Include(c => c.ContestCategory)
                .Include(c => c.User)
                .ThenInclude(c => c.Institution)
                .Include(c => c.User)
                .ThenInclude(i => i.Country)
                .ToListAsync();
        }

        public Task<List<ContestRequest>> GetContestAcceptedFighterRequests(int contestId, int categoryId)
        {
            return _context.ContestRequests.Where(m => m.ContestId == contestId &&
                                                       m.ContestCategoryId == categoryId && 
                                                       m.Type == ContestRoleType.Fighter &&
                                                       m.Status == ContestRoleRequestStatus.Accepted)
                .Include(c => c.ContestCategory)
                .Include(c => c.User)
                .ThenInclude(c => c.Institution)
                .Include(c => c.User)
                .ThenInclude(i => i.Country)
                .ToListAsync();
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
                _context.ContestRequests.AddAsync(request);
            }
            else
            {
                _context.ContestRequests.Attach(request);
            }

            return _context.SaveChangesAsync();
        }
    }
}
