using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Institutions.Gyms
{
    public class GymDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator GymDto(Institution institution)
        {
            return new GymDto
            {
                Id = institution.Id,
                Name = institution.Name
            };
        }
    }
}
