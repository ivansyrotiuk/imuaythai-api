using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Dictionaries
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
