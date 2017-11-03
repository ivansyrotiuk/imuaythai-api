using IMuaythai.DataAccess.Models;

namespace IMuaythai.Fights
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
