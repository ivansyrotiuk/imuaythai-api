using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Data;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories
{
    public class InstitutionsRepository : IInstitutionsRepository
    {
        private readonly ApplicationDbContext _context;

        public InstitutionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Institution>> Find(Expression<Func<Institution, bool>> predicate)
        {
            return _context.Institutions.Where(predicate).ToListAsync();
        }

        public Task<Institution> Get(int id)
        {
            return _context.Institutions.Include(i => i.Country).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<List<Institution>> GetAll()
        {
            return _context.Institutions.Include(i => i.Country).ToListAsync();
        }

        public Task<List<Institution>> GetContinentalFederations()
        {
            return _context.Institutions.Include(i => i.Country).Where(i => i.InstitutionType == InstitutionType.ContinentalFederation).ToListAsync();
        }

        public Task<List<Institution>> GetNationalFederations()
        {
            return _context.Institutions.Include(i => i.Country).Where(i => i.InstitutionType == InstitutionType.NationalFederation).ToListAsync();
        }

        public Task<List<Institution>> GetGyms()
        {
            return _context.Institutions.Include(i => i.Country).Where(i => i.InstitutionType == InstitutionType.Gym).ToListAsync();
        }

        public Task<List<Institution>> GetWorldFederations()
        {
            return _context.Institutions.Include(i => i.Country).Where(i => i.InstitutionType == InstitutionType.WorldFederation).ToListAsync();
        }

        public Task<List<Institution>> GetByCountry(Country country)
        {
            return _context.Institutions.Include(i => i.Country)
                .Where(i => i.CountryId == country.Id && i.InstitutionType == InstitutionType.Gym ||
                            i.CountryId == country.Id && i.InstitutionType == InstitutionType.NationalFederation || 
                            i.Country.Continent == country.Continent && i.InstitutionType == InstitutionType.ContinentalFederation || 
                            i.InstitutionType == InstitutionType.WorldFederation)
                .ToListAsync();
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
            else
            {
                _context.Entry(institution).State = EntityState.Modified;
            }
            return _context.SaveChangesAsync();
        }
    }
}
