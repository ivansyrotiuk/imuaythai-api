using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Dictionaries
{
    public class ContestTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator ContestTypeDto(ContestType type)
        {
            return new ContestTypeDto
            {
                Id = type.Id,
                Name = type.Name
            };
        }
    }
}
