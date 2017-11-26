using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Contests;

namespace IMuaythai.Api.Mappers
{
    public class ContestsProfile:Profile
    {
        public ContestsProfile()
        {
            CreateMap<ContestRing, RingAvailabilityModel>();
            CreateMap<Contest, ContestModel>()
                .ForMember(dest => dest.ContestCategories, opt => opt.MapFrom(src => src.ContestCategoriesMappings ?? new List<ContestCategoriesMapping>()))
                .ForMember(dest => dest.Rings, opt => opt.MapFrom(src => ConvertToContestRingModel(src)));

            CreateMap<ContestModel, Contest>();

            CreateMap<ContestRequest, ContestRequestModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User == null ? string.Empty :  src.User.FirstName + ' ' + src.User.Surname))
                .ForMember(dest => dest.InstitutionName, opt => opt.MapFrom(src => src.Institution == null ? string.Empty : src.Institution.Name))
                .ForMember(dest => dest.ContestName, opt => opt.MapFrom(src => src.Contest == null ? string.Empty : src.Contest.Name))
                .ForMember(dest => dest.ContestCategoryName, opt => opt.MapFrom(src => src.ContestCategory == null ? string.Empty : src.ContestCategory.Name))
                .ForMember(dest => dest.AcceptedByUserName, opt => opt.MapFrom(src => src.AcceptedByUser == null ? string.Empty : src.AcceptedByUser.FirstName + ' ' + src.AcceptedByUser.Surname));
        }

        private List<ContestRingModel> ConvertToContestRingModel(Contest contest)
        {
            return contest.Rings?.GroupBy(r => r.From.Date).Select(g => new ContestRingModel
            {
                ContestDay = g.Key,
                RingsCount = g.Count(),
                ContestId = g.Select(e => e.ContestId).FirstOrDefault(),
                RingsAvilability = g.Select(a => new RingAvailabilityModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    From = a.From,
                    To = a.To
                }).ToList()
            }).ToList();
        } 
}
}
