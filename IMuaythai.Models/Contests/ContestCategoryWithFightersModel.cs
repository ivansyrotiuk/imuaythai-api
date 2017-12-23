using System.Collections.Generic;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Models.Users;

namespace IMuaythai.Models.Contests
{
    public class ContestCategoryWithFightersModel : ContestCategoryModel
    {
        public List<FighterModel> Fighters { get; set; }
    }
}
