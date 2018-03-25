using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Fights;
using IMuaythai.Users;

namespace IMuaythai.Fights
{
    public class FightsProfile : Profile
    {
        public FightsProfile()
        {
            CreateMap<Fight, FightModel>();

            CreateMap<Fight, FightResponseModel>().ForMember(dest => dest.Points,
                    opt => opt.MapFrom(src => ConvertToFightPointModels(src)))
                .ForMember(dest => dest.Judges,
                    opt => opt.MapFrom(src => src.FightJudgesMappings.Where(j => j.Main == 0).Select(m => m.Judge)))
                .ForMember(dest => dest.MainJudge,
                    opt => opt.MapFrom(src =>
                        src.FightJudgesMappings.Where(j => j.Main == 1).Select(m => m.Judge).FirstOrDefault()))
                .ForMember(dest => dest.RedAthleteWon, opt => opt.MapFrom(src => src.BlueAthlete != null && src.RedAthlete.Id == src.WinnerId))
                .ForMember(dest => dest.BlueAthleteWon, opt => opt.MapFrom(src => src.BlueAthlete != null && src.BlueAthlete.Id == src.WinnerId));
        }

        private List<FightPointModel> ConvertToFightPointModels(Fight fight)
        {
            if (fight == null)
            {
                return new List<FightPointModel>();
            }

            return fight.FightPoints?.GroupBy(p => p.JudgeId).Select(groupedPoints => new FightPointModel
            {
                JudgeId = groupedPoints.Key,
                JudgeName = groupedPoints.FirstOrDefault()?.Judge?.GetFullName(),
                Rounds = ConvertToRoundPointsModels(fight, groupedPoints)
            }).ToList();
        }

        private static List<FightPointModel.RoundPointsModel> ConvertToRoundPointsModels(Fight fight, IGrouping<string, FightPoint> groupedPoints)
        {
            var roundPointsList = new List<FightPointModel.RoundPointsModel>();

            var roundPointsDictionary = GetRoundPointsDictionary(fight, groupedPoints);

            for (var i = 1; i <= fight.Structure.Round.RoundsCount; i++)
            {
                var points = roundPointsDictionary.ContainsKey(i) ? roundPointsDictionary[i] : GetEmptyRoundPoints(i);
                roundPointsList.Add(points);
            }
            return roundPointsList;
        }

        private static Dictionary<int, FightPointModel.RoundPointsModel> GetRoundPointsDictionary(Fight fight, IGrouping<string, FightPoint> groupedPoints)
        {
            return groupedPoints.OrderBy(r => r.RoundId).GroupBy(r => r.RoundId).Select(r =>
                new FightPointModel.RoundPointsModel
                {
                    RoundId = r.Key,
                    RedFighterPoints = r.Where(f => f.FighterId == fight.RedAthleteId).Select(fp =>
                        new FightPointModel.PointsModel
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
                    BlueFighterPoints = r.Where(f => f.FighterId == fight.BlueAthleteId).Select(fp =>
                        new FightPointModel.PointsModel
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
                }).ToDictionary(t => t.RoundId, t => t);
        }

        private static FightPointModel.RoundPointsModel GetEmptyRoundPoints(int roundId)
        {
            return new FightPointModel.RoundPointsModel
            {
                RoundId = roundId,
                BlueFighterPoints = new FightPointModel.PointsModel(),
                RedFighterPoints = new FightPointModel.PointsModel()
            };
        }
    }
}
