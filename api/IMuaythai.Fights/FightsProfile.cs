using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Fights;

namespace IMuaythai.Fights
{
    public class FightsProfile : Profile
    {
        public FightsProfile()
        {
            CreateMap<Fight, FightModel>().
                ForMember(dest => dest.Points, opt => opt.MapFrom(src => ConvertToFightPointModels(src)))
                .ForMember(dest => dest.Judges, opt => opt.MapFrom(src => src.FightJudgesMappings.Where(j => j.Main == 0).Select(m => m.Judge)))
                .ForMember(dest => dest.MainJudge, opt => opt.MapFrom(src => src.FightJudgesMappings.Where(j => j.Main == 1).Select(m => m.Judge).FirstOrDefault()));
        }

        private List<FightPointModel> ConvertToFightPointModels(Fight src)
        {
            return src?.FightPoints?.GroupBy(p => p.JudgeId).Select(p => new FightPointModel
            {
                JudgeId = p.Key,
                JudgeName = p.FirstOrDefault()?.Judge?.FirstName + " " + p.FirstOrDefault()?.Judge?.Surname,
                Rounds = p.OrderBy(r => r.RoundId).GroupBy(r => r.RoundId).Select(r => new FightPointModel.RoundPointsModel
                {
                    RoundId = r.Key,
                    RedFighterPoints = r.Where(f => f.FighterId == src.RedAthleteId).Select(fp => new FightPointModel.PointsModel
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
                    BlueFighterPoints = r.Where(f => f.FighterId == src.BlueAthleteId).Select(fp => new FightPointModel.PointsModel
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
            }).ToList() ?? new List<FightPointModel>();
        }
    }
}
