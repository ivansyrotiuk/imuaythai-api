using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IInstitutionRepository
    {
        Institution Get(int id);
        IEnumerable<Institution> GetAll();
        IEnumerable<Institution> Find(Func<Institution, bool> predicate);
        void Save(Institution institution);
        void Remove(int id);
    }
}
