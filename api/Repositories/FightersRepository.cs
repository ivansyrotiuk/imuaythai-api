using System;
using System.Collections.Generic;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public class FightersRepository : IUsersRepository
    {
        private IUsersRepository _baseRepository;

        public FightersRepository(IUsersRepository repository)
        {
            _baseRepository = repository;
        }

        public IEnumerable<ApplicationUser> Find(Func<ApplicationUser, bool> predicate)
        {
            return _baseRepository.Find(predicate);
        }

        public ApplicationUser Get(string id)
        {
            return _baseRepository.Get(id);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public void Remove(string id)
        {
            _baseRepository.Remove(id);
        }

        public void Save(ApplicationUser institution)
        {
            _baseRepository.Save(institution);
        }
    }
}
