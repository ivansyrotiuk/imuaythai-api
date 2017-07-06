using Microsoft.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    class InstitutionsesRepository : IInstitutionsRepository
    {
        private readonly ApplicationDbContext _context;

        public InstitutionsesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Institution> Find(Func<Institution, bool> predicate)
        {
            return _context.Institutions.Where(predicate);
        }

        public Institution Get(int id)
        {
            return _context.Institutions.Include(i => i.Country).FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Institution> GetAll()
        {
            return _context.Institutions;
        }

        public void Remove(int id)
        {
            var intitution = _context.Institutions.FirstOrDefault(i => i.Id == id);
            _context.Institutions.Remove(intitution);
            _context.SaveChanges();
        }

        public void Save(Institution institution)
        {
            if (institution.Id == 0)
            {
                _context.Institutions.Add(institution);
            }

            _context.SaveChanges();
        }
    }
}
