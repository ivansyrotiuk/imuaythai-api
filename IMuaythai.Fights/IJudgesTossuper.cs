using System;
using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Models;
using IMuaythai.Fights.JudgeSelectors;

namespace IMuaythai.Fights
{
    public interface IJudgesTossuper
    {
        List<Fight> Tossup(List<ContestRequest> judgesRequests, List<Fight> fights);
    }

    public class JudgesTossuper : IJudgesTossuper
    {
        private const int MaxRegularJudgesCount = 5;
        private const int MinRegularJudgesCount = 3;
        private readonly List<IAppropriateJudgeSelector> _judgeSelectors;
        private readonly List<IAppropriateJudgeSelector> _timeKeeperSelectors;
        private readonly List<IAppropriateJudgeSelector> _refereeSelectors;

        public JudgesTossuper(IFightDurationCalculator fightDurationCalculator)
        {
            _judgeSelectors = new List<IAppropriateJudgeSelector>
            {
                new InstitutionRestrictedSelector(fightDurationCalculator),
                new SameInstitutionAllowedSelector(fightDurationCalculator)
            };
            _timeKeeperSelectors = new List<IAppropriateJudgeSelector>
            {
                new InstitutionRestrictedSelector(fightDurationCalculator),
                new SameInstitutionAllowedSelector(fightDurationCalculator)
            };
            _refereeSelectors = new List<IAppropriateJudgeSelector>
            {
                new WomenRestrictedSelector(new InstitutionRestrictedSelector(fightDurationCalculator)),
                new InstitutionRestrictedSelector(fightDurationCalculator),
                new WomenRestrictedSelector(new SameInstitutionAllowedSelector(fightDurationCalculator)),
                new SameInstitutionAllowedSelector(fightDurationCalculator)
            };
        }

        public List<Fight> Tossup(List<ContestRequest> judgesRequests, List<Fight> fights)
        {
            var timeKeepers = judgesRequests.Where(request => request.JudgeType == ContestJudgeType.TimeKeepper).ToList();
            var regularJudges = judgesRequests.Where(request => request.JudgeType == ContestJudgeType.Regular).ToList();
            var referees = judgesRequests.Where(request => request.JudgeType == ContestJudgeType.Referee).ToList();
            var mainJudges = judgesRequests.Where(request => request.JudgeType == ContestJudgeType.MainJudge).ToList();

            foreach (var fight in fights)
            {
                var contestFights = fights.Where(f => f.Id != fight.Id).ToList();
                fight.RefereeId = GetAppropriateJudgeToFight(fight, contestFights, referees, _refereeSelectors);
                fight.TimeKeeperId = GetAppropriateJudgeToFight(fight, contestFights, timeKeepers, _timeKeeperSelectors);
                fight.FightJudgesMappings = new List<FightJudgesMapping>
                {
                    new FightJudgesMapping
                    {
                        FightId = fight.Id,
                        JudgeId = GetAppropriateJudgeToFight(fight, contestFights, mainJudges, _judgeSelectors),
                        Main = 1
                    }
                };

                var judgesCount = (regularJudges.Count > MinRegularJudgesCount ? MaxRegularJudgesCount : MinRegularJudgesCount);
                for (var i = 0; i < judgesCount; i++)
                {
                    fight.FightJudgesMappings.Add(new FightJudgesMapping
                    {
                        FightId = fight.Id,
                        JudgeId = GetAppropriateJudgeToFight(fight, contestFights, regularJudges, _judgeSelectors)
                    });
                }
            }

            return fights;
        }

        private string GetAppropriateJudgeToFight(Fight fight, List<Fight> fights, List<ContestRequest> judgesRequests, List<IAppropriateJudgeSelector> judgeSelectors)
        {
            if (judgesRequests.Count == 0)
            {
                throw new Exception("There are no main judge requests. Please define the main judges of the contest.");
            }

            foreach (var judgeSelector in judgeSelectors)
            {
                var judgeId = judgeSelector.SelectJudgeForFight(fight, fights, judgesRequests);
                if (string.IsNullOrEmpty(judgeId))
                {
                    continue;
                }

                return judgeId;
            }

            return null;
            //todo throw right exception
            //throw new Exception("The are not enough judges to organize the contest.");
        }
    }


}
