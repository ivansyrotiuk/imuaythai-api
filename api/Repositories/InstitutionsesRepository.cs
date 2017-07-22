using Microsoft.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Extensions;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    class InstitutionsesRepository : IInstitutionsRepository
    {
        private readonly ApplicationDbContext _context;

        public InstitutionsesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Institution>> Find(Func<Institution, bool> predicate)
        {
            var institutions = _context.Institutions.Where(predicate).AsQueryable();
            return institutions.ToListAsync();
        }

        public Task<Institution> Get(int id)
        {
            return _context.Institutions.Include(i => i.Country).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<List<Institution>> GetAll()
        {
            return _context.Institutions.ToListAsync();
        }

        public Task Remove(int id)
        {
            var intitution = _context.Institutions.FirstOrDefault(i => i.Id == id);
            _context.Institutions.Remove(intitution);
            return _context.SaveChangesAsync();
        }

        public Task Save(Institution institution)
        {
            if (institution.Id == 0)
            {
                _context.Institutions.Add(institution);
            }

            return _context.SaveChangesAsync();
        }
    }
}
