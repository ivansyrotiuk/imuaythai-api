using MuaythaiSportManagementSystemApi.Dictionaries;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuaythaiSportManagementSystemApi.Fights
{
    public class FightDto
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

        public byte? KO { get; set; }

        public string Ring { get; set; }

        public int? KOTime { get; set; }

        public int? NextFightId { get; set; }

        public List<FightPointDto> FightPoints { get; set; }
        public List<JudgeDto> Judges { get; set; }

        public Fight NextFight { get; set; }
        public Contest Contest { get; set; }
        public ContestCategoryDto ContestCategory { get; set; }
        public FightStructure Structure { get; set; }
        public FighterDto RedAthlete { get; set; }
        public FighterDto BlueAthlete { get; set; }
        public FighterDto TimeKeeper { get; set; }
        public FighterDto Referee { get; set; }
        public FighterDto Winner { get; set; }
        public JudgeDto MainJudge { get; set; }

        public FightDto()
        {

        }

        public FightDto(Fight fight)
        {
            if (fight == null)
            {
                return;
            }

            Id = fight.Id;
            ContestId = fight.ContestId;
            StructureId = fight.StructureId;
            ContestCategoryId = fight.ContestCategoryId;
            RedAthleteId = fight.RedAthleteId;
            BlueAthleteId = fight.BlueAthleteId;
            WinnerId = fight.WinnerId;
            StartDate = fight.StartDate;
            TimeKeeperId = fight.TimeKeeperId;
            RefereeId = fight.RefereeId;
            KO = fight.KO;

            Ring = fight.Ring;
            KOTime = fight.KOTime;
            NextFightId = fight.NextFightId;
    
            RedAthlete = (FighterDto)fight.RedAthlete;
            BlueAthlete = (FighterDto) fight.BlueAthlete;
            TimeKeeper = (FighterDto)fight.TimeKeeper;
            Referee = (FighterDto)fight.Referee;
            FightPoints = fight.FightPoints?.Select(p => (FightPointDto)p).ToList();
            Judges = fight.FightJudgesMappings?.Where(j => j.Main == 0).Select(p => (JudgeDto)p.Judge).ToList();
            MainJudge = fight.FightJudgesMappings?.Where(j => j.Main > 0).Select(p => (JudgeDto)p.Judge).FirstOrDefault();
            ContestCategory = (ContestCategoryDto)fight?.ContestCategory;
        }

        public static explicit operator FightDto(Fight fight)
        {
            return new FightDto(fight);
        }
    }
}
