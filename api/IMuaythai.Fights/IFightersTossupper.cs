using System.Collections.Generic;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Fights
{
    public interface IFightersTossupper
    {
        void Tossup(List<ApplicationUser> fighters, FightsTree tree);
    }
}