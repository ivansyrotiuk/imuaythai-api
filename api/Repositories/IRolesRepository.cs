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
        Task<List<IdentityRole>> GetAll();
    }

    public class RolesRepository : IRolesRepository
    {
        private readonly ApplicationDbContext _context;

        public RolesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<IdentityRole>> GetAll()
        {
           return _context.Roles.ToListAsync();
        }
    }
}
