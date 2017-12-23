﻿using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Repositories.Dictionaries;

namespace IMuaythai.Repositories.Contests
{
    public interface IContestCategoryMappingsRepository
    {
        Task<List<ContestCategoriesMapping>> GetByContest(int contestId);
        Task SaveCategoryMappings(int contestId, List<ContestCategoryModel> contestCategoriesMappings);
    }
}
