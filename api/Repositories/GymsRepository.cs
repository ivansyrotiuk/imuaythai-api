using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    class GymsRepository : IInstitutionsRepository
    {
        private readonly IInstitutionsRepository _baseRepository;

        public GymsRepository(IInstitutionsRepository repository)
        {
            _baseRepository = repository;
        }

        public Task<List<Institution>> Find(Func<Institution, bool> predicate)
        {
            return _baseRepository.Find(predicate);//.Where(i => i.InstitutionType == InstitutionType.Gym);
        }

        public Task<Institution> Get(int id)
        {
            return _baseRepository.Get(id);
        }

        public Task<List<Institution>> GetAll()
        {
            return _baseRepository.GetAll();//.Where(i => i.InstitutionType == InstitutionType.Gym);
        }

        public void Remove(int id)
        {
            _baseRepository.Remove(id);
        }

        public void Save(Institution institution)
        {
            _baseRepository.Save(institution);
        }
    }
}
