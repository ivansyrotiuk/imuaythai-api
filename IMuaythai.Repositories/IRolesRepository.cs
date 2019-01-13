using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories
{
    public interface IRolesRepository
    {
        Task<IdentityRole> Get(string name);
        Task<List<IdentityRole>> GetAll();
        Task<List<IdentityRole>> GetPublicRoles();
        Task<List<IdentityRole>> GetContestRoles();
        Task<List<IdentityRole>> GetUserRoles(string userId);
    }

    public class RolesRepository : IRolesRepository
    {
        private readonly ApplicationDbContext _context;

        public RolesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IdentityRole> Get(string name)
        {
            return _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
        }

        public Task<List<IdentityRole>> GetAll()
        {
           return _context.Roles.ToListAsync();
        }

        public Task<List<IdentityRole>> GetContestRoles()
        {
            return _context.Roles.Where(r => r.NormalizedName.Contains( "FIGHTER") || r.NormalizedName.Contains("JUDGE") || r.NormalizedName.Contains("DOCTOR")).ToListAsync();
        }

        public Task<List<IdentityRole>> GetUserRoles(string userId)
        {
            var userRolesMapping = _context.UserRoles.Where(userRole => userRole.UserId == userId).Select(userRole => userRole.RoleId);
            return _context.Roles.Where(r => userRolesMapping.Contains(r.Id)).ToListAsync();
        }

        public Task<List<IdentityRole>> GetPublicRoles()
        {
            return _context.Roles.Where(r => !r.NormalizedName.Contains("FEDERATION") && r.NormalizedName != "ADMIN").ToListAsync();
        }
    }
}
