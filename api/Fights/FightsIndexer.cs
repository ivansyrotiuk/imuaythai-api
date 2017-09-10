using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuaythaiSportManagementSystemApi.Fights
{
    public class FightsIndexer : IFightsIndexer
    {
        public List<IndexedFight> CreateIndex(List<Fight> fights)
        {
            FightsTree fightsTree = new FightsTree(fights);
            List<IndexedFight> index = fightsTree.CreateTreeIndex();
            return index;
        }
    }
}
