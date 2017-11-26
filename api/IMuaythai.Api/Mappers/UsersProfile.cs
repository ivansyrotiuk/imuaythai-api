using System;
using System.Linq;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Users;

namespace IMuaythai.Api.Mappers
{
    public class UsersProfile: Profile
    {
        public UsersProfile()
        {
            CreateMap<ApplicationUser, UserModel>()
                .ForMember(dest => dest.CountryName,
                    options => options.MapFrom(src => src.Country == null ? string.Empty : src.Country.Name))
                .ForMember(dest => dest.GymName,
                    options => options.MapFrom(src => src.Institution == null ? string.Empty : src.Institution.Name))
                .ForMember(dest => dest.Roles,
                    options => options.MapFrom(src => src.Roles.Select(role => role.RoleId)));
           
            CreateMap<ApplicationUser, FighterModel>().ForMember(dest => dest.Age,
                options => options.MapFrom(src => Math.Abs(DateTime.Today.Year - src.Birthdate.Year)));

            CreateMap<ApplicationUser, JudgeModel>();
            CreateMap<CreateUserModel, ApplicationUser>();
        }
    }
}