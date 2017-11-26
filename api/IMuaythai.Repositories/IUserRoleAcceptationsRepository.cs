using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Data;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories
{
    public interface IUserRoleRequestsRepository
    {
        Task<UserRoleRequest> Get(int id);
        Task<List<UserRoleRequest>> GetUserRequests(string userId);
        Task<List<UserRoleRequest>> GetPendingRequests();
        Task Save(UserRoleRequest acceptation);
    }

    public class UserRoleRequestsRepository : IUserRoleRequestsRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRequestsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<UserRoleRequest> Get(int id)
        {
            return _context.UserRoleRequests.Include(u => u.User).Include(u => u.AcceptedByUser).Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<List<UserRoleRequest>> GetUserRequests(string userId)
        {
            return _context.UserRoleRequests.Where(u => u.UserId == userId).Include(u => u.User).Include(u => u.AcceptedByUser).Include(u => u.Role).ToListAsync();
        }

        public Task<List<UserRoleRequest>> GetPendingRequests()
        {
            return _context.UserRoleRequests.Where(u => u.Status == UserRoleRequestStatus.Pending).Include(u => u.User).Include(u => u.AcceptedByUser).Include(u => u.Role).ToListAsync();
        }

        public Task Save(UserRoleRequest acceptation)
        {
            if (acceptation.Id == 0)
            {
                _context.UserRoleRequests.Add(acceptation);
            }
            else
            {
                _context.Entry(acceptation).State = EntityState.Modified;
            }

            return _context.SaveChangesAsync();
        }
    }
}
