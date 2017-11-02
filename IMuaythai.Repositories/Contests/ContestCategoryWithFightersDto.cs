using System.Collections.Generic;
using IMuaythai.DataAccess.Models;
using IMuaythai.Repositories.Dictionaries;
using IMuaythai.Repositories.Users;

namespace IMuaythai.Repositories.Contests
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
