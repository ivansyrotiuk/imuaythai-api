using System.Collections.Generic;
using IMuaythai.Models.Contests;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Models.Users;

namespace IMuaythai.Models.Fights
{
    public class FightResponseModel : FightModel
    {
        public ContestResponseModel Contest { get; set; }
        public List<FightPointModel> Points { get; set; }
        public List<JudgeModel> Judges { get; set; }
        public FightModel NextFight { get; set; }
        public ContestResponseModel ContestResponse { get; set; }
        public ContestCategoryModel ContestCategory { get; set; }
        public FightStructureModel Structure { get; set; }
        public FighterModel RedAthlete { get; set; }
        public FighterModel BlueAthlete { get; set; }
        public FighterModel TimeKeeper { get; set; }
        public FighterModel Referee { get; set; }
        public FighterModel Winner { get; set; }
        public JudgeModel MainJudge { get; set; }
        public bool BlueAthleteWon { get; set; }
        public bool RedAthleteWon { get; set; }
    }
}