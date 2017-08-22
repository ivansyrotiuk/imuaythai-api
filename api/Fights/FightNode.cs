using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;
namespace MuaythaiSportManagementSystemApi.Fights
{
    public class FightNode
    {
        public Fight Fight { get; set; }
        public FightNode Parent { get; set; }
        public List<FightNode> Children { get; set; }
        public bool IsFilled { get; set; }

        public FightNode()
        {
            Children = new List<FightNode>(2);
        }

        public FightNode(FightNode parentFight):this()
        {
            Parent = parentFight;
        }

        public FightNode(Fight fight, FightNode parent) : this(parent)
        {
            Fight = fight;
        }
    }
}
