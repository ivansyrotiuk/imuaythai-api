using System.Collections.Generic;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Fights
{
    public interface IFightsIndexer
    {
        List<IndexedFight> CreateIndex(List<Fight> fights);
    }
}