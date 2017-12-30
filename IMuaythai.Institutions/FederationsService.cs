using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Institutions;
using IMuaythai.Repositories;
using Microsoft.AspNetCore.Identity;

namespace IMuaythai.Institutions
{
    public class FederationsService : InstitutionsService, IFederationsService
    {
        private readonly IInstitutionsRepository _repository;
        private readonly IMapper _mapper;

        public FederationsService(IInstitutionsRepository repository, IUsersRepository usersRepository,  UserManager<ApplicationUser> userManager, IMapper mapper) : base(repository, usersRepository, userManager, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InstitutionResponseModel>> GetNationalFederations()
        {
            var federations = await _repository.GetNationalFederations();
            return _mapper.Map<IEnumerable<InstitutionResponseModel>>(federations);
        }

        public async Task<IEnumerable<InstitutionResponseModel>> GetContinentalFederations()
        {
            var federations = await _repository.GetContinentalFederations();
            return _mapper.Map<IEnumerable<InstitutionResponseModel>>(federations);
        }

        public async Task<IEnumerable<InstitutionResponseModel>> GetWorldFederations()
        {
            var federations = await _repository.GetWorldFederations();
            return _mapper.Map<IEnumerable<InstitutionResponseModel>>(federations);
        }
    }
}