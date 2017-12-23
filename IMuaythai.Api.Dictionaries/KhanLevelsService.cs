using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Repositories.Dictionaries;

namespace IMuaythai.Dictionaries
{
    public class KhanLevelsService : IKhanLevelsService
    {
        private readonly IKhanLevelsRepository _repository;
        private readonly IMapper _mapper;

        public KhanLevelsService(IKhanLevelsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<KhanLevelModel>> GetKhanLevels()
        {
            var levels = await _repository.GetAll();
            return _mapper.Map<IEnumerable<KhanLevelModel>>(levels);
        }

        public async Task<KhanLevelModel> GetKhanLevel(int id)
        {
            var level = await _repository.Get(id);
            return _mapper.Map<KhanLevelModel>(level);
        }

        public async Task<KhanLevelModel> Save(KhanLevelModel levelModel)
        {
            var level = _mapper.Map<KhanLevel>(levelModel);
            await _repository.Save(level);

            return _mapper.Map<KhanLevelModel>(level);
        }

        public async Task Remove(int id)
        {
            await _repository.Remove(id);
        }
    }
}