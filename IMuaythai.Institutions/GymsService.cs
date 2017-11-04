using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.Models.Institutions;
using IMuaythai.Repositories;

namespace IMuaythai.Institutions
{
    public class GymsService : InstitutionsService, IGymsService
    {
        private readonly IInstitutionsRepository _repository;

        public GymsService(IInstitutionsRepository repository):base(repository)
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