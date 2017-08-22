using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Fights
{
    public interface IFightsTreePersister
    {
        Task Save(FightsTree tree);
    }
}