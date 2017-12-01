using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.Models.Dictionaries;

namespace IMuaythai.Dictionaries
{
    public interface IKhanLevelsService
    {
        Task<IEnumerable<KhanLevelModel>> GetKhanLevels();
        Task<KhanLevelModel> GetKhanLevel(int id);
        Task<KhanLevelModel> Save(KhanLevelModel levelModel);
        Task Remove(int id);
    }
}