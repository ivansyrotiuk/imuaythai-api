using System;
using System.Collections.Generic;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Contests;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Models.Users;

namespace IMuaythai.Models.Fights
{
    public class FightModel
    {
        public int Id { get; set; }
        public int ContestId { get; set; }
        public int StructureId { get; set; }
        public int? ContestCategoryId { get; set; }
        public string RedAthleteId { get; set; }

        public string BlueAthleteId { get; set; }

        public string WinnerId { get; set; }

        public DateTime? StartDate { get; set; }

        public string TimeKeeperId { get; set; }

        public string RefereeId { get; set; }

        // ReSharper disable once InconsistentNaming
        public byte? KO { get; set; }

        public string Ring { get; set; }

        // ReSharper disable once InconsistentNaming
        public int? KOTime { get; set; }

        public int? NextFightId { get; set; }
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
    }
}
