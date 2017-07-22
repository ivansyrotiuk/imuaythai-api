using System;
using System.Collections.Generic;
using MuaythaiSportManagementSystemApi.Models;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Repositories
{
    public class FightersRepository : IUsersRepository
    {
        private IUsersRepository _baseRepository;

        public FightersRepository(IUsersRepository repository)
        {
            _baseRepository = repository;
        }

        public Task<List<ApplicationUser>> Find(Func<ApplicationUser, bool> predicate)
        {
            return _baseRepository.Find(predicate);
        }

        public Task<ApplicationUser> Get(string id)
        {
            return _baseRepository.Get(id);
        }

        public Task<List<ApplicationUser>> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public Task Remove(string id)
        {
            return _baseRepository.Remove(id);
        }

        public Task Save(ApplicationUser institution)
        {
            return _baseRepository.Save(institution);
        }
    }
}
