using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Repositories.Dictionaries;

namespace IMuaythai.Dictionaries
{
    public class FightStructuresService: IFightStructuresService
    {
        private readonly IFightStructuresRepository _fightStructuresRepository;
        private readonly IMapper _mapper;

        public FightStructuresService(IFightStructuresRepository fightStructuresRepository, IMapper mapper)
        {
            _fightStructuresRepository = fightStructuresRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FightStructureModel>> GetFightStructures()
        {
            var fightStructures = await _fightStructuresRepository.GetAll();
            return _mapper.Map<IEnumerable<FightStructureModel>>(fightStructures);
        }

        public async Task<FightStructureModel> GetFightStructure(int id)
        {
            var fightStructure = await _fightStructuresRepository.Get(id);
            return _mapper.Map<FightStructureModel>(fightStructure);
        }

        public async Task<FightStructureModel> SaveFightStructure(FightStructureModel fightStructureModel)
        {
            var fightStructure = _mapper.Map<FightStructure>(fightStructureModel);
            await _fightStructuresRepository.Save(fightStructure);
            return _mapper.Map<FightStructureModel>(fightStructure);
        }

        public async Task RemoveFightStructure(int id)
        {
            await _fightStructuresRepository.Remove(id);
        }
    }
}