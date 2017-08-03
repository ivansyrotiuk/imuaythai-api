using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IWeightAgeCategoriesRepository
    {
        Task<WeightAgeCategory> Get(int id);
        Task<List<WeightAgeCategory>> GetAll();
        Task<List<WeightAgeCategory>> Find(Func<WeightAgeCategory, bool> predicate);
        Task Save(WeightAgeCategory category);
        Task Remove(int id);
    }
}
