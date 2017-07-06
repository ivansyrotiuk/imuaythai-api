using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Dictionaries
{
    public class ContestRangeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static explicit operator ContestRangeDto(ContestRange range)
        {
            return new ContestRangeDto
            {
                Id = range.Id,
                Name = range.Name
            };
        }
    }
}
