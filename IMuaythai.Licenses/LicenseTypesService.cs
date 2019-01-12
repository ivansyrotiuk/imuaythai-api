using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.Models.Licenses;
using IMuaythai.Repositories;

namespace IMuaythai.Licenses
{
    public interface ILicenseTypesService
    {
        Task<IEnumerable<LicenseTypeResponseModel>> GetLicenseTypes();
        Task CreateLicenseTypes();
    }

    public class LicenseTypesService : ILicenseTypesService
    {
        private readonly ILicenseTypesRepository _repository;
        private readonly IMapper _mapper;

        public LicenseTypesService(ILicenseTypesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LicenseTypeResponseModel>> GetLicenseTypes()
        {
            var licenseTypes = await _repository.GetAll();
            return _mapper.Map<IEnumerable<LicenseTypeResponseModel>>(licenseTypes);
        }

        public Task CreateLicenseTypes()
        {
            return _repository.CreateLicenseTypes();
        }
    }
}