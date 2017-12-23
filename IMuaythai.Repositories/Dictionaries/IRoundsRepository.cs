using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Dictionaries
{
    public interface IRoundsRepository
    {
        Task<Round> Get(int id);
        Task<List<Round>> GetAll();
        Task<List<Round>> Find(Func<Round, bool> predicate);
        Task Save(Round round);
        Task Remove(int id);
    }
}
