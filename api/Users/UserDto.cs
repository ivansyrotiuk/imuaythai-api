using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Users
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }

        public static explicit operator UserDto(ApplicationUser user)
        {
            return new UserDto
            {
                Id = user.Id,
                Firstname = user.FirstName,
                Surname = user.Surname
            };
        }
    }

   
}
