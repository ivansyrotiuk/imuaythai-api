using System;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Licenses;
using IMuaythai.Repositories;
using IMuaythai.Services;

namespace IMuaythai.Licenses
{
    public interface ILicenseService
    {
        Task<LicenseResponseModel> CreateLicense(int licenseTypeId, string userId, int institutionId);
        Task<FighterLicenseResponseModel> CreateFighterLicense(int licenseTypeId, string userId);
        Task<JudgeLicenseResponseModel> CreateJudgeLicense(int licenseTypeId, string userId);
        Task<CoachLicenseResponseModel> CreateCoachLicense(int licenseTypeId, string userId);
        Task<GymLicenseResponseModel> CreateGymLicense(int licenseTypeId, int institutionId, string userId);
    }

    public class LicenseService : ILicenseService
    {
        private readonly ILicenseTypesRepository _licenseTypesRepository;
        private readonly ILicensesRepository _licensesRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public LicenseService(ILicenseTypesRepository licenseTypesRepository, ILicensesRepository licensesRepository, IMapper mapper, IEmailSender emailSender)
        {
            _licenseTypesRepository = licenseTypesRepository;
            _licensesRepository = licensesRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task<LicenseResponseModel> CreateLicense(int licenseTypeId, string userId, int institutionId)
        {
            var type = await _licenseTypesRepository.Get(licenseTypeId);
            switch (type.Kind)
            {
                case LicenseKinds.Coach:
                    return await CreateCoachLicense(licenseTypeId, userId);
                case LicenseKinds.Judge:
                    return await CreateJudgeLicense(licenseTypeId, userId);
                case LicenseKinds.Fighter:
                    return await CreateFighterLicense(licenseTypeId, userId);
                case LicenseKinds.Gym:
                    return await CreateGymLicense(licenseTypeId, institutionId, userId);
                default:
                    throw new NotSupportedException();
            }
        }

        public async Task<FighterLicenseResponseModel> CreateFighterLicense(int licenseTypeId, string fighterId)
        {
            var licenseType = await _licenseTypesRepository.Get(licenseTypeId);
            var license = new FighterLicense
            {
                LicenseTypeId = licenseType.Id,
                Currency = licenseType.Currency,
                FighterId = fighterId,
                From = DateTime.Today,
                To = DateTime.Today.AddDays(licenseType.Duration),
                Kind = licenseType.Kind,
                Price = licenseType.Price,
                Paid = false
            };

            await _licensesRepository.Save(license);
            return _mapper.Map<FighterLicenseResponseModel>(license);
        }

        public async Task<JudgeLicenseResponseModel> CreateJudgeLicense(int licenseTypeId, string judgeId)
        {
            var licenseType = await _licenseTypesRepository.Get(licenseTypeId);
            var license = new JudgeLicense
            {
                LicenseTypeId = licenseType.Id,
                Currency = licenseType.Currency,
                JudgeId = judgeId,
                From = DateTime.Today,
                To = DateTime.Today.AddDays(licenseType.Duration),
                Kind = licenseType.Kind,
                Price = licenseType.Price,
                Paid = false
            };

            await _licensesRepository.Save(license);
            return _mapper.Map<JudgeLicenseResponseModel>(license);
        }

        public async Task<CoachLicenseResponseModel> CreateCoachLicense(int licenseTypeId, string coachId)
        {
            var licenseType = await _licenseTypesRepository.Get(licenseTypeId);
            var license = new CoachLicense
            {
                LicenseTypeId = licenseType.Id,
                Currency = licenseType.Currency,
                CoachId = coachId,
                From = DateTime.Today,
                To = DateTime.Today.AddDays(licenseType.Duration),
                Kind = licenseType.Kind,
                Price = licenseType.Price,
                Paid = false
            };

            await _licensesRepository.Save(license);
            return _mapper.Map<CoachLicenseResponseModel>(license);
        }

        public async Task<GymLicenseResponseModel> CreateGymLicense(int licenseTypeId, int institutionId, string userId)
        {
            var licenseType = await _licenseTypesRepository.Get(licenseTypeId);
            var license = new GymLicense
            {
                LicenseTypeId = licenseType.Id,
                Currency = licenseType.Currency,
                InstitutionId = institutionId,
                From = DateTime.Today,
                To = DateTime.Today.AddDays(licenseType.Duration),
                Kind = licenseType.Kind,
                Price = licenseType.Price,
                Paid = false
            };

            await _licensesRepository.Save(license);
            return _mapper.Map<GymLicenseResponseModel>(license);
        }
    }
}