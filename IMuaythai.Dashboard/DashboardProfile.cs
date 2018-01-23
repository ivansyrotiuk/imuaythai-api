using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dashboard;

namespace IMuaythai.Dashboard
{
    public class DashboardProfile : AutoMapper.Profile
    {
        public DashboardProfile()
        {
            CreateMap<Contest, ContestEvent>()
                .ForMember(dest => dest.ContestId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.From, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.To, opt => opt.MapFrom(src => src.Date.AddDays(src.Duration)))
                .ForMember(dest => dest.Organizator, opt => opt.PreCondition(src => src.Institution != null))
                .ForMember(dest => dest.Organizator, opt => opt.MapFrom(src => src.Institution.Name))
                .ForMember(dest => dest.Country, opt => opt.PreCondition(src => src.Country != null))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name));
        }
    }
}
