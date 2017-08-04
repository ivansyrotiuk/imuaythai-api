using Microsoft.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface ICountriesRepository
    {
        Task<Country> Get(int id);
        Task<Country> Get(string code);
        Task<List<Country>> GetAll();
        Task<List<Country>> Find(Func<Country, bool> predicate);
    }

    public class CountriesRepository : ICountriesRepository
    {
        private readonly ApplicationDbContext _context;

        public CountriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Country>> Find(Func<Country, bool> predicate)
        {
            return _context.Countries.Where(predicate).AsQueryable().ToListAsync();
        }

        public Task<Country> Get(int id)
        {
            return _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<Country> Get(string code)
        {
            return _context.Countries.FirstOrDefaultAsync(c => c.Code == code);
        }

        public Task<List<Country>> GetAll()
        {
            return _context.Countries.ToListAsync();
        }
    }
}
