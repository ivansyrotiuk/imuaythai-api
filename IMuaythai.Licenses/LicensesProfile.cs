using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Licenses;

namespace IMuaythai.Licenses
{
    public class LicensesProfile : Profile
    {
        public LicensesProfile()
        {
            CreateMap<FighterLicense, FighterLicenseResponseModel>();
            CreateMap<JudgeLicense, JudgeLicenseResponseModel>();
            CreateMap<CoachLicense, CoachLicenseResponseModel>();
            CreateMap<GymLicense, GymLicenseResponseModel>();
            CreateMap<LicenseType, LicenseTypeResponseModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LicenseTypeNameResolver.ResolveLicenseTypeName(src)));

            CreateMap<FighterLicense, UserLicense>();
            CreateMap<JudgeLicense, UserLicense>();
            CreateMap<GymLicense, UserLicense>();
            CreateMap<CoachLicense, UserLicense>();
        }
    }
}
