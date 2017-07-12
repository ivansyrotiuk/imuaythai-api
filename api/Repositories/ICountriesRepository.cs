using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface ICountriesRepository
    {
        Country Get(int id);
        Country Get(string code);
        IEnumerable<Country> GetAll();
        IEnumerable<Country> Find(Func<Country, bool> predicate);
    }

    public class CountriesRepository : ICountriesRepository
    {
        private readonly ApplicationDbContext _context;

        public CountriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> Find(Func<Country, bool> predicate)
        {
            return _context.Countries.Where(predicate);
        }

        public Country Get(int id)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == id);
        }

        public Country Get(string code)
        {
            return _context.Countries.FirstOrDefault(c => c.Code == code);
        }

        public IEnumerable<Country> GetAll()
        {
            return _context.Countries;
        }
    }
}
