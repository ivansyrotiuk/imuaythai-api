using System.Threading.Tasks;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.Repositories
{
    public interface ILicensesRepository
    {
        Task<FighterLicense> GetFighterLicense(int id);
        Task<JudgeLicense> GetJudgeLicense(int id);
        Task<CoachLicense> GetCoachLicense(int id);
        Task<GymLicense> GetGymLicense(int id);
        Task<License> GetLicense(int id);
        Task<License> Save(License license);
    }

    public class LicensesRepository : ILicensesRepository
    {
        private readonly ApplicationDbContext _context;

        public LicensesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<FighterLicense> GetFighterLicense(int id)
        {
            return _context.FighterLicenses.FirstOrDefaultAsync(l => l.Id == id);
        }

        public Task<JudgeLicense> GetJudgeLicense(int id)
        {
            return _context.JudgeLicenses.FirstOrDefaultAsync(l => l.Id == id);

        }

        public Task<CoachLicense> GetCoachLicense(int id)
        {
            return _context.CoachLicenses.FirstOrDefaultAsync(l => l.Id == id);
        }

        public Task<GymLicense> GetGymLicense(int id)
        {
            return _context.GymLicenses.FirstOrDefaultAsync(l => l.Id == id);
        }

        public Task<License> GetLicense(int id)
        {
            return _context.Licenses.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<License> Save(License license)
        {
            if (license.Id == default(int))
            {
                _context.Licenses.Add(license);
            }
            else
            {
                _context.Entry(license).State = EntityState.Modified;
            }
          
            await _context.SaveChangesAsync();
            return license;
        }
    }
}