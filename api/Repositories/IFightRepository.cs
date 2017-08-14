using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IFightRepository
    {
        Task<List<Fight>> GetAll();
        Task<Fight> Get(int id);
        Task Save(Fight fight);
        Task<List<Fight>> Find(Expression<Func<Fight, bool>> predicate);
    }
}