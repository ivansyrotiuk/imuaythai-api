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
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => ResolveLicenseTypeName(src)));
        }

        private static string ResolveLicenseTypeName(LicenseType src)
        {
            var ownership = string.Empty;
            switch (src.Kind)
            {
                case LicenseKinds.Fighter:
                    ownership = "zawodnika";
                    break;
                case LicenseKinds.Coach:
                    ownership = "trenera";
                    break;
                case LicenseKinds.Judge:
                    ownership = "sędziego";
                    break;
                case LicenseKinds.Gym:
                    ownership = "klubowa";
                    break;
            }

            var duration = src.OneOff ? "jednorazowa" : $"na {src.Duration} dni";

            return $"Licencja {ownership} {duration}";
        }
    }
}
