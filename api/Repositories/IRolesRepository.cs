using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IRolesRepository
    {
        Task<IdentityRole> Get(string name);
        Task<List<IdentityRole>> GetAll();
        Task<List<IdentityRole>> GetPublicRoles();
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

        public Task<List<IdentityRole>> GetPublicRoles()
        {
            return _context.Roles.Where(r => !r.NormalizedName.Contains("FEDERATION") && r.NormalizedName != "ADMIN").ToListAsync();
        }
    }
}
