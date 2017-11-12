using System.Threading.Tasks;

namespace IMuaythai.Fights
{
    public interface IFightDrawsService
    {
        Task<string> GenerateFightsDraws(int contestId, int categoryId);
        Task<string> GetDraws(int contestId, int categoryId);
        Task<string> RegenerateDraws(int contestId, int categoryId);
        Task<string> TossupFightsDraws(int contestId, int categoryId);
    }
}