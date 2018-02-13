using System;

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
    }
}
