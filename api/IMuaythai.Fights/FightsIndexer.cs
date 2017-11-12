using System.Collections.Generic;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Fights
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
