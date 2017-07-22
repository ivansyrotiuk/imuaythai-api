using Microsoft.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IUserRoleAcceptationsRepository
    {
        Task<UserRoleAcceptation> Get(int id);
        Task<List<UserRoleAcceptation>> GetUserAcceptations(string userId);
        Task Save(UserRoleAcceptation acceptation);
    }

    public class UserRoleAcceptationsRepository : IUserRoleAcceptationsRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRoleAcceptationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<UserRoleAcceptation> Get(int id)
        {
            return _context.UserRoleAcceptations.Include(u => u.User).Include(u => u.AcceptedByUser).Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<List<UserRoleAcceptation>> GetUserAcceptations(string userId)
        {
            return _context.UserRoleAcceptations.Where(u => u.UserId == userId).Include(u => u.User).Include(u => u.AcceptedByUser).Include(u => u.Role).ToListAsync();
        }

        public Task Save(UserRoleAcceptation acceptation)
        {
            if (acceptation.Id == 0)
            {
                _context.UserRoleAcceptations.Add(acceptation);
            }
            else
            {
                _context.UserRoleAcceptations.Attach(acceptation);
            }

            return _context.SaveChangesAsync();
        }
    }
}
