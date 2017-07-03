using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    class GymsRepository : IInstitutionRepository
    {
        private readonly IInstitutionRepository _baseRepository;

        public GymsRepository(IInstitutionRepository repository)
        {
            _baseRepository = repository;
        }

        public IEnumerable<Institution> Find(Func<Institution, bool> predicate)
        {
            return _baseRepository.Find(predicate);//.Where(i => i.InstitutionType == InstitutionType.Gym);
        }

        public Institution Get(int id)
        {
            return _baseRepository.Get(id);
        }

        public IEnumerable<Institution> GetAll()
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
