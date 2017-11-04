using System;
using System.Collections.Generic;
using System.Linq;
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

        public byte? KO { get; set; }

        public string Ring { get; set; }

        public int? KOTime { get; set; }

        public int? NextFightId { get; set; }

        public List<FightPointModel> Points { get; set; }
        public List<JudgeModel> Judges { get; set; }

        public Fight NextFight { get; set; }
        public ContestModel Contest { get; set; }
        public ContestCategoryModel ContestCategory { get; set; }
        public FightStructureModel Structure { get; set; }
        public FighterModel RedAthlete { get; set; }
        public FighterModel BlueAthlete { get; set; }
        public FighterModel TimeKeeper { get; set; }
        public FighterModel Referee { get; set; }
        public FighterModel Winner { get; set; }
        public JudgeModel MainJudge { get; set; }
       

        public FightModel()
        {

        }

        public FightModel(Fight fight)
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
    
            RedAthlete = (FighterModel)fight.RedAthlete;
            BlueAthlete = (FighterModel) fight.BlueAthlete;
            TimeKeeper = (FighterModel)fight.TimeKeeper;
            Referee = (FighterModel)fight.Referee;
            Points = fight.FightPoints?.GroupBy(p => p.JudgeId).Select(p => new FightPointModel
            {
                    JudgeId = p.Key,
                    JudgeName = p.FirstOrDefault()?.Judge?.FirstName + " " + p.FirstOrDefault()?.Judge?.Surname,
                    Rounds = p.OrderBy(r => r.RoundId).GroupBy(r => r.RoundId).Select(r => new FightPointModel.RoundPointsModel
                    {
                        RoundId = r.Key,
                        RedFighterPoints = r.Where(f => f.FighterId == fight.RedAthleteId).Select(fp => new FightPointModel.PointsModel
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
                        BlueFighterPoints = r.Where(f => f.FighterId == fight.BlueAthleteId).Select(fp => new FightPointModel.PointsModel
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
        
            Judges = fight.FightJudgesMappings?.Where(j => j.Main == 0).Select(p => (JudgeModel)p.Judge).ToList();
            MainJudge = fight.FightJudgesMappings?.Where(j => j.Main > 0).Select(p => (JudgeModel)p.Judge).FirstOrDefault();
            ContestCategory = (ContestCategoryModel)fight?.ContestCategory;
            Structure = (FightStructureModel)fight.Structure;
            Contest = (ContestModel) fight.Contest;
        }

        public static explicit operator FightModel(Fight fight)
        {
            return new FightModel(fight);
        }
    }
}
