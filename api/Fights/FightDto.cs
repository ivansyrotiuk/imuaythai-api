using MuaythaiSportManagementSystemApi.Dictionaries;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MuaythaiSportManagementSystemApi.Contests;

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

        public List<FightPointDto> Points { get; set; }
        public List<JudgeDto> Judges { get; set; }

        public Fight NextFight { get; set; }
        public ContestDto Contest { get; set; }
        public ContestCategoryDto ContestCategory { get; set; }
        public FightStructureDto Structure { get; set; }
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
            Points = fight.FightPoints?.GroupBy(p => p.JudgeId).Select(p => new FightPointDto
            {
                    JudgeId = p.Key,
                    JudgeName = p.FirstOrDefault()?.Judge?.FirstName + " " + p.FirstOrDefault()?.Judge?.Surname,
                    Rounds = p.OrderBy(r => r.RoundId).GroupBy(r => r.RoundId).Select(r => new FightPointDto.RoundPoints
                    {
                        RoundId = r.Key,
                        RedFighterPoints = r.Where(f => f.FighterId == fight.RedAthleteId).Select(fp => new FightPointDto.Points
                        {
                            Accepted = fp.Accepted,
                            Cautions = fp.Cautions,
                            FighterPoints = fp.Points,
                            Injury = fp.Injury,
                            InjuryTime = fp.InjuryTime,
                            J = fp.J,
                            KnockDown = fp.KnockDown,
                            Warnings = fp.Warnings,
                            X = fp.X
                        }).FirstOrDefault(),
                        BlueFighterPoints = r.Where(f => f.FighterId == fight.BlueAthleteId).Select(fp => new FightPointDto.Points
                        {
                            Accepted = fp.Accepted,
                            Cautions = fp.Cautions,
                            FighterPoints = fp.Points,
                            Injury = fp.Injury,
                            InjuryTime = fp.InjuryTime,
                            J = fp.J,
                            KnockDown = fp.KnockDown,
                            Warnings = fp.Warnings,
                            X = fp.X
                        }).FirstOrDefault(),
                    }).ToList()
                }).ToList();
        
            Judges = fight.FightJudgesMappings?.Where(j => j.Main == 0).Select(p => (JudgeDto)p.Judge).ToList();
            MainJudge = fight.FightJudgesMappings?.Where(j => j.Main > 0).Select(p => (JudgeDto)p.Judge).FirstOrDefault();
            ContestCategory = (ContestCategoryDto)fight?.ContestCategory;
            Structure = (FightStructureDto)fight.Structure;
            Contest = (ContestDto) fight.Contest;
        }

        public static explicit operator FightDto(Fight fight)
        {
            return new FightDto(fight);
        }
    }
}
