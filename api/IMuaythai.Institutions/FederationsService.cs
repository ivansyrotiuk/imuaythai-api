using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Institutions;
using IMuaythai.Repositories;
using Microsoft.AspNetCore.Identity;

namespace IMuaythai.Institutions
{
    public class FederationsService : InstitutionsService, IFederationsService
    {
        private readonly IInstitutionsRepository _repository;

        public FederationsService(IInstitutionsRepository repository, IUsersRepository usersRepository, IRolesRepository rolesRepository, UserManager<ApplicationUser> userManager) : base(repository, usersRepository, rolesRepository, userManager)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InstitutionModel>> GetNationalFederations()
        {
            var entities = await _repository.GetNationalFederations();
            var federations = entities.Select(i => (InstitutionModel)i).ToList();
            return federations;
        }

        public async Task<IEnumerable<InstitutionModel>> GetContinentalFederations()
        {
            var entities = await _repository.GetContinentalFederations();
            var federations = entities.Select(i => (InstitutionModel)i).ToList();
            return federations;
        }

        public async Task<IEnumerable<InstitutionModel>> GetWorldFederations()
        {
            var entities = await _repository.GetWorldFederations();
            var federations = entities.Select(i => (InstitutionModel)i).ToList();
            return federations;
        }
    }
}