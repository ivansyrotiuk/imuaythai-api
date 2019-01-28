using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Licenses;
using IMuaythai.Repositories;
using Microsoft.AspNetCore.Identity;

namespace IMuaythai.Licenses
{
    public interface ILicenseTypesService
    {
        Task<IEnumerable<LicenseTypeResponseModel>> GetLicenseTypes(ApplicationUser user);
        Task CreateLicenseTypes();
    }

    public class LicenseTypesService : ILicenseTypesService
    {
        private readonly ILicenseTypesRepository _repository;
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;

        public LicenseTypesService(ILicenseTypesRepository repository, IMapper mapper, IRolesRepository rolesRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _rolesRepository = rolesRepository;
        }

        public async Task<IEnumerable<LicenseTypeResponseModel>> GetLicenseTypes(ApplicationUser user)
        {
            var licenseTypes = await _repository.GetAll();

            licenseTypes = user.InstitutionId.HasValue 
                ? licenseTypes.Where(type => !type.OneOff).ToList() 
                : licenseTypes.Where(type => type.OneOff).ToList();

            var userRoles = await _rolesRepository.GetUserRoles(user.Id);

            bool ContainsRole(List<IdentityRole> roles, string roleName)
            {
                return roles.Any(r => r.NormalizedName.Equals(roleName));
            }

            licenseTypes = licenseTypes.Where(type =>
                    type.Kind == LicenseKinds.Gym && ContainsRole(userRoles, "GYMADMIN") ||
                    type.Kind == LicenseKinds.Fighter && ContainsRole(userRoles, "FIGHTER") ||
                    type.Kind == LicenseKinds.Coach && ContainsRole(userRoles, "COACH") ||
                    type.Kind == LicenseKinds.Judge && ContainsRole(userRoles, "JUDGE"))
                .ToList();

            var result = _mapper.Map<IEnumerable<LicenseTypeResponseModel>>(licenseTypes).ToArray();
            foreach (var licenseType in result)
            {
                if (licenseType.Kind == LicenseKinds.Gym)
                {
                    licenseType.InstitutionId = user.InstitutionId;
                }
            }

            return result.OrderBy(type => type.Kind).ToArray();
        }

        public Task CreateLicenseTypes()
        {
            return _repository.CreateLicenseTypes();
        }
    }
}