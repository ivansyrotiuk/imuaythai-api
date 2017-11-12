using System.Collections.Generic;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Fights
{
    public interface IFightsIndexer
    {
        List<IndexedFight> CreateIndex(List<Fight> fights);
    }
}