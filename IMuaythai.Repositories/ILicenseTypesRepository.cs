using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories
{
    public interface ILicenseTypesRepository
    {
        Task<List<LicenseType>> GetAll();
        Task<LicenseType> Get(int id);
        Task CreateLicenseTypes();
    }

    public class LicenseTypesRepository : ILicenseTypesRepository
    {
        private readonly ApplicationDbContext _context;

        public LicenseTypesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<LicenseType> Get(int id)
        {
            return _context.LicenseTypes.FirstOrDefaultAsync(t => t.Id == id);
        }

        public Task<List<LicenseType>> GetAll()
        {
            return _context.LicenseTypes.ToListAsync();
        }

        public Task CreateLicenseTypes()
        {
            _context.LicenseTypes.AddRange(new[]
            {
                //new LicenseType
                //{
                //    CountryId = 177,
                //    Currency = "PLN",
                //    Duration = 365,
                //    Kind = LicenseKinds.Fighter,
                //    OneOff = false,
                //    Price = 50
                //},
                //new LicenseType
                //{
                //    CountryId = 177,
                //    Currency = "PLN",
                //    Duration = 365,
                //    Kind = LicenseKinds.Judge,
                //    OneOff = false,
                //    Price = 60
                //},
                //new LicenseType
                //{
                //    CountryId = 177,
                //    Currency = "PLN",
                //    Duration = 365,
                //    Kind = LicenseKinds.Coach,
                //    OneOff = false,
                //    Price = 40
                //},
                //new LicenseType
                //{
                //    CountryId = 177,
                //    Currency = "PLN",
                //    Duration = 365,
                //    Kind = LicenseKinds.Gym,
                //    OneOff = false,
                //    Price = 600
                //},

                ///////////////////////////////
                new LicenseType
                {
                    CountryId = 177,
                    Currency = "PLN",
                    Duration = 1,
                    Kind = LicenseKinds.Fighter,
                    OneOff = true,
                    Price = 57
                },
                new LicenseType
                {
                    CountryId = 177,
                    Currency = "PLN",
                    Duration = 1,
                    Kind = LicenseKinds.Judge,
                    OneOff = true,
                    Price = 67
                },
                new LicenseType
                {
                    CountryId = 177,
                    Currency = "PLN",
                    Duration = 1,
                    Kind = LicenseKinds.Coach,
                    OneOff = true,
                    Price = 47
                },
                new LicenseType
                {
                    CountryId = 177,
                    Currency = "PLN",
                    Duration = 1,
                    Kind = LicenseKinds.Gym,
                    OneOff = true,
                    Price = 677
                },
            });

            return _context.SaveChangesAsync();
        }

    }
}