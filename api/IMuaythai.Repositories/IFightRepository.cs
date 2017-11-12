using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories
{
    public interface IFightRepository
    {
        Task<List<Fight>> GetAll();
        Task<Fight> Get(int id);
        Task Save(Fight fight);
        Task<List<Fight>> Find(Expression<Func<Fight, bool>> predicate);
        Task<List<Contest>> GetContests();
    }
}