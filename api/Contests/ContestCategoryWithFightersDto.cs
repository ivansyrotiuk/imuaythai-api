using MuaythaiSportManagementSystemApi.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Users;

namespace MuaythaiSportManagementSystemApi.Contests
{
    public class ContestCategoryWithFightersDto : ContestCategoryDto
    {
        public List<FighterDto> Fighters { get; set; }

        public ContestCategoryWithFightersDto()
        {

        }

        public ContestCategoryWithFightersDto(ContestCategory category) : base(category)
        {
        }
    }
}
