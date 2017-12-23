using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Repositories.Dictionaries;

namespace IMuaythai.Dictionaries
{
    public interface IContestTypesService
    {
        Task<IEnumerable<ContestTypeModel>> GetContestTypes();
        Task<ContestTypeModel> GetContestType(int id);
        Task<ContestTypeModel> SaveContestType(ContestTypeModel contestTypeModel);
        Task RemoveContestType(int id);
    }

    public class ContestTypesService : IContestTypesService
    {
        private readonly IContestTypesRepository _repository;
        private readonly IMapper _mapper;

        public ContestTypesService(IContestTypesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContestTypeModel>> GetContestTypes()
        {
            var contestTypes = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ContestTypeModel>>(contestTypes);
        }

        public async Task<ContestTypeModel> GetContestType(int id)
        {
            var contestType = await _repository.Get(id);
            return _mapper.Map<ContestTypeModel>(contestType);
        }

        public async Task<ContestTypeModel> SaveContestType(ContestTypeModel contestTypeModel)
        {
            var contestType = _mapper.Map<ContestType>(contestTypeModel);
            await _repository.Save(contestType);
            return _mapper.Map<ContestTypeModel>(contestType);
        }

        public async Task RemoveContestType(int id)
        {
            await _repository.Remove(id);
        }
    }
}