using System.Collections.Generic;

namespace IMuaythai.Api.Fights
{
    public class FightPointDto
    {
        public string JudgeId { get; set; }
        public string JudgeName { get; set; }
        public List<RoundPoints> Rounds { get; set; }
        

        public class RoundPoints
        {
            public int RoundId { get; set; }
            public Points RedFighterPoints { get; set; }
            public Points BlueFighterPoints { get; set; }
        }

        public class Points
        {
            public int Id { get; set; }
            public string FighterId { get; set; }
            public string JudgeId { get; set; }
            public int FighterPoints { get; set; }
            public int FightId { get; set; }
            public int Cautions { get; set; }
            public int Warnings { get; set; }
            public int KnockDown { get; set; }
            public int J { get; set; }
            public int X { get; set; }
            public string Injury { get; set; }
            public int? InjuryTime { get; set; }
            public bool Accepted { get; set; }
        }
    }


}