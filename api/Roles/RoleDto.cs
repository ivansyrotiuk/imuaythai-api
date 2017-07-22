using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Roles
{
    public class RoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public RoleDto()
        {

        }

        public RoleDto(IdentityRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }

        public static explicit operator RoleDto(IdentityRole role)
        {
            return new RoleDto(role);
        }
    }
}
