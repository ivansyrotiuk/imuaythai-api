using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Institutions;
using IMuaythai.Repositories;
using Microsoft.AspNetCore.Identity;

namespace IMuaythai.Institutions
{
    public class GymsService : InstitutionsService, IGymsService
    {
        private readonly IInstitutionsRepository _repository;

        public GymsService(IInstitutionsRepository repository, IUsersRepository usersRepository, UserManager<ApplicationUser> userManager) :base(repository, usersRepository, userManager)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GymModel>> GetGyms()
        {
            var gymsEntities = await _repository.GetGyms();
            var gyms = gymsEntities.Select(i => (GymModel)i).ToList();
            return gyms;
        }

        public async Task<IEnumerable<GymModel>> GetCountryGyms(int countryId)
        {
            var entities = await _repository.Find(i => i.CountryId == countryId);
            return entities.Select(i => (GymModel)i).ToList();
        }
    }
}