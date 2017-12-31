using System;
using System.Linq;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Users;

namespace IMuaythai.Users
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
            CreateMap<UserModel, ApplicationUser>();

            CreateMap<CreateUserRoleRequestModel, UserRoleRequest>()
                .ForMember(dest => dest.User, options => options.Ignore())
                .ForMember(dest => dest.AcceptedByUser, options => options.Ignore())
                .ForMember(dest => dest.Role, options => options.Ignore());

            CreateMap<UpdateUserRoleRequestModel, UserRoleRequest>()
                .ForMember(dest => dest.User, options => options.Ignore())
                .ForMember(dest => dest.AcceptedByUser, options => options.Ignore())
                .ForMember(dest => dest.Role, options => options.Ignore());

            CreateMap<UserRoleRequest, UserRoleRequestResponseModel>()
                .ForMember(dest => dest.UserName, options => options.PreCondition(src => src.User != null))
                .ForMember(dest => dest.UserName, options => options.MapFrom(src => $"{src.User.Surname} {src.User.FirstName}"))
                .ForMember(dest => dest.AcceptedByUserName, options => options.PreCondition(src => src.AcceptedByUser != null))
                .ForMember(dest => dest.AcceptedByUserName, options => options.MapFrom(src => $"{src.AcceptedByUser.Surname} {src.AcceptedByUser.FirstName}"))
                .ForMember(dest => dest.RoleName, options => options.PreCondition(src => src.Role != null))
                .ForMember(dest => dest.RoleName, options => options.MapFrom(src => src.Role.Name));

            CreateMap<UserRoleRequest, UserRoleRequestModel>();

        }
    }
}