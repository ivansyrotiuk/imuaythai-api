using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Users;

namespace IMuaythai.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserModel, ApplicationUser>();
        }
    }
}
