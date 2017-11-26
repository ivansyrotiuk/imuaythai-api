using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.Models.Dictionaries;

namespace IMuaythai.Dictionaries
{
    public interface IFightStructuresService
    {
        Task<IEnumerable<FightStructureModel>> GetFightStructures();
        Task<FightStructureModel> GetFightStructure(int id);
        Task<FightStructureModel> SaveFightStructure(FightStructureModel fightStructureModel);
        Task RemoveFightStructure(int id);
    }
}