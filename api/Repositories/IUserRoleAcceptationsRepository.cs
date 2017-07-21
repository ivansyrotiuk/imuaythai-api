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
        Task<List<UserRoleAcceptation>> GetUserAcceptations(string userId);
    }

    public class UserRoleAcceptationsRepository : IUserRoleAcceptationsRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRoleAcceptationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<UserRoleAcceptation>> GetUserAcceptations(string userId)
        {
            return _context.UserRoleAcceptations.Where(u => u.UserId == userId).Include(u => u.User).Include(u => u.AcceptedByUser).Include(u => u.Role).ToListAsync();
        }
    }
}
