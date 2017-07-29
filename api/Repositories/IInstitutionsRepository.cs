using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public interface IInstitutionsRepository
    {
        Task<Institution> Get(int id);
        Task<List<Institution>> GetAll();
        Task<List<Institution>> GetGyms();
        Task<List<Institution>> GetNationalFederations();
        Task<List<Institution>> GetContinentalFederations();
        Task<List<Institution>> GetWorldFederations();
        Task<List<Institution>> GetByCountry(Country country);
        Task<List<Institution>> Find(Func<Institution, bool> predicate);
        Task Save(Institution institution);
        Task Remove(int id);
        
    }
}
