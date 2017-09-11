using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MuaythaiSportManagementSystemApi.Fights
{
    public class IndexedFight
    {
        public int Index { get; set; }
        public int DrawDeepLevel { get; set; }
        public Fight Fight { get; set; }
        public IndexedFight(Fight fight)
        {
            Fight = fight;
        }
    }
}
