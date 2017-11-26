using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Contests;
using IMuaythai.Models.Locations;

namespace IMuaythai.Api.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContestRequest, ContestRequestModel>()
                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => src.User == null ? "" : $"{src.User.FirstName} {src.User.Surname}"))
                .ForMember(dest => dest.InstitutionName,
                    opt => opt.MapFrom(src => src.Institution == null ? string.Empty : src.Institution.Name))
                .ForMember(dest => dest.ContestName,
                    opt => opt.MapFrom(src => src.Contest == null ? string.Empty : src.Contest.Name))
                .ForMember(dest => dest.ContestCategoryName,
                    opt => opt.MapFrom(src => src.ContestCategory == null ? string.Empty : src.ContestCategory.Name))
                .ForMember(dest => dest.AcceptedByUserName,
                    opt => opt.MapFrom(src => src.AcceptedByUser == null ? "" : $"{src.AcceptedByUser.FirstName} {src.AcceptedByUser.Surname}"));

            CreateMap<ContestRequestModel, ContestRequest>();
            CreateMap<Country, CountryModel>();
        }
    }
}
