using Microsoft.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IUsersRepository
    {
        Task<ApplicationUser> Get(string id);
        Task<List<ApplicationUser>> GetAll();
        Task<List<ApplicationUser>> Find(Func<ApplicationUser, bool> predicate);
        void Save(ApplicationUser institution);
        void Remove(string id);
    }

    public class UsersRepository : IUsersRepository
    {
        private ApplicationDbContext _context;

        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ApplicationUser> Get(string id)
        {
            return _context.Users.Include(u => u.Country).FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<List<ApplicationUser>> GetAll()
        {
            return _context.Users.ToListAsync();
        }

        public Task<List<ApplicationUser>> Find(Func<ApplicationUser, bool> predicate)
        {
            return _context.Users.Where(predicate).AsQueryable().ToListAsync();
        }

        public void Save(ApplicationUser institution)
        {
            if (string.IsNullOrEmpty(institution.Id))
            {
                _context.Users.Add(institution);
            }
            else
            {
                _context.Users.Attach(institution);
            }

            _context.SaveChanges();
        }

        public void Remove(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
