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
        ApplicationUser Get(string id);
        IEnumerable<ApplicationUser> GetAll();
        IEnumerable<ApplicationUser> Find(Func<ApplicationUser, bool> predicate);
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

        public ApplicationUser Get(string id)
        {
            return _context.Users.Include(u => u.Country).FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.Users;
        }

        public IEnumerable<ApplicationUser> Find(Func<ApplicationUser, bool> predicate)
        {
            return _context.Users.Where(predicate);
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
