using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Institutions;
using IMuaythai.Repositories;
using Microsoft.AspNetCore.Identity;

namespace IMuaythai.Institutions
{
    public class GymsService : InstitutionsService, IGymsService
    {
        private readonly IInstitutionsRepository _repository;
        private readonly IMapper _mapper;

        public GymsService(IInstitutionsRepository repository, IUsersRepository usersRepository, IMapper mapper, UserManager<ApplicationUser> userManager) :base(repository, usersRepository, userManager, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GymModel>> GetGyms()
        {
            var gyms = await _repository.GetGyms();
            return _mapper.Map<IEnumerable<GymModel>>(gyms);
        }

        public async Task<IEnumerable<GymModel>> GetCountryGyms(int countryId)
        {
            var gyms = await _repository.Find(i => i.CountryId == countryId);
            return _mapper.Map<IEnumerable<GymModel>>(gyms);
        }
    }
}