using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Data;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories
{
    public interface IUsersRepository
    {
        Task<ApplicationUser> Get(string id);
        Task<List<ApplicationUser>> GetAll();
        Task<List<ApplicationUser>> Find(Func<ApplicationUser, bool> predicate);
        Task<List<ApplicationUser>> GetInstitutionMembers(int value);
        Task Save(ApplicationUser user);
        Task Remove(string id);
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;

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

        public Task<List<ApplicationUser>> GetInstitutionMembers(int institutionId)
        {
            //TODO: there is no Roles in application user anymore. Get Roles from _context.UserRoles
            return _context.Users.Include(u => u.Roles).Where(u => u.InstitutionId == institutionId).ToListAsync();
        }

        public Task Save(ApplicationUser user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Id))
                {
                    _context.Users.Add(user);
                }
                else
                {
                    _context.Entry(user).State = EntityState.Modified;
                }

                return _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is ApplicationUser)
                    {
                        foreach (var property in entry.Metadata.GetProperties())
                        {
                    
                            entry.Property(property.Name).OriginalValue = entry.Property(property.Name).CurrentValue;
                        }
                    }
                    else
                    {
                        throw new NotSupportedException("Don't know how to handle concurrency conflicts for " + entry.Metadata.Name);
                    }
                }

                return _context.SaveChangesAsync();
            }
        }

        public Task Remove(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            _context.Users.Remove(user);
            return _context.SaveChangesAsync();
        }
    }
}
