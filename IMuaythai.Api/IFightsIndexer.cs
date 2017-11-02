using System.Collections.Generic;
using IMuaythai.Api.Fights;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Api
{
    public interface IFightsIndexer
    {
        List<IndexedFight> CreateIndex(List<Fight> fights);
    }
}