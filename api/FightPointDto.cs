using System;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Users;

namespace MuaythaiSportManagementSystemApi.Fights
{
    public class FightPointDto
    {
        public int Id { get; set; }

        public int RoundId { get; set; }

        public string FighterId { get; set; }
        public string JudgeId { get; set; }
        public int Points { get; set; }
        public int FightId { get; set; }
        public int Cautions { get; set; }

        public int Warnings { get; set; }

        public int KnockDown { get; set; }

        public int J { get; set; }
        public int X { get; set; }
        public string Injury { get; set; }
        public int? InjuryTime { get; set; }
        public bool Accepted { get; set; }

        public JudgeDto Judge { get; set; }
        public FighterDto Fighter { get; set; }

        public FightPointDto()
        {

        }

        public FightPointDto(FightPoint point)
        {
            Id = point.Id;
            RoundId = point.RoundId;
            FighterId = point.FighterId;
            JudgeId = point.JudgeId;
            Points = point.Points;
            FightId = point.FightId;
            Cautions = point.Cautions;
            Warnings = point.Warnings;
            KnockDown = point.KnockDown;
            J = point.J;
            X = point.X;
            Injury = point.Injury;
            InjuryTime = point.InjuryTime;
            Accepted = point.Accepted;
            Judge = (JudgeDto)point.Judge;
            Fighter = (FighterDto)point.Fighter;
        }

        public static explicit operator FightPointDto(FightPoint point)
        {
            return new FightPointDto(point);
        }
    }
}