using System.Collections.Generic;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Fights
{
    public interface IFightersTossupper
    {
        void Tossup(List<ApplicationUser> fighters, FightsTree tree);
    }
}