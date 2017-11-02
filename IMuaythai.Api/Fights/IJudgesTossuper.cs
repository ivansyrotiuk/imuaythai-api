using System;
using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Api.Fights
{
    public interface IJudgesTossuper
    {
        List<Fight> Tossup(List<ContestRequest> judgesRequests, List<Fight> fights);
    }

    public class JudgesTossuper : IJudgesTossuper
    {
        private readonly List<IAppropriateJudgeSelector> _judgeSelectors;
        private readonly List<IAppropriateJudgeSelector> _timeKeeperSelectors;
        private readonly List<IAppropriateJudgeSelector> _refereeSelectors;

        public JudgesTossuper(IFightDurationCalculator fightDurationCalculator)
        {
            _judgeSelectors = new List<IAppropriateJudgeSelector>
            {
                new InstitutionRestrictedJudgeSelector(fightDurationCalculator),
                new SameInstitutionAllowedJudgeSelector(fightDurationCalculator)
            };
            _timeKeeperSelectors = new List<IAppropriateJudgeSelector>
            {
                new InstitutionRestrictedTimeKeeperSelector(fightDurationCalculator),
                new SameInstitutionAllowedTimeKeeperSelector(fightDurationCalculator)
            };
            _refereeSelectors = new List<IAppropriateJudgeSelector>
            {
                new InstitutionRestrictedRefereeSelector(fightDurationCalculator),
                new SameInstitutionAllowedRefereeSelector(fightDurationCalculator)
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
                var contestFights = fights.SkipWhile(f => f.Id == fight.Id).ToList();
                fight.RefereeId = GetAppropriateJudgeToFight(fight, contestFights, referees, _refereeSelectors);
                fight.TimeKeeperId = GetAppropriateJudgeToFight(fight, contestFights, timeKeepers, _timeKeeperSelectors);
                fight.FightJudgesMappings = new List<FightJudgesMapping>();

                string mainJudgeId = GetAppropriateJudgeToFight(fight, contestFights, mainJudges, _judgeSelectors);
                fight.FightJudgesMappings.Add(new FightJudgesMapping
                {
                    FightId = fight.Id,
                    JudgeId = mainJudgeId,
                    Main = 1
                });
 
                for (int i = 0; i < (regularJudges.Count > 3 ? 5 : 3); i++)
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
            //throw new Exception("The are not enough judges to organize the contest.");
        }
    }

    public interface IAppropriateJudgeSelector
    {
        string SelectJudgeForFight(Fight fight, List<Fight> contestFights, List<ContestRequest> judgeRequests);
    }

    public abstract class BaseJudgeSelector : IAppropriateJudgeSelector
    {
        protected readonly IFightDurationCalculator FightDurationCalculator;

        protected BaseJudgeSelector(IFightDurationCalculator fightDurationCalculator)
        {
            FightDurationCalculator = fightDurationCalculator;
        }

        public virtual string SelectJudgeForFight(Fight fight, List<Fight> contestFights, List<ContestRequest> judgeRequests)
        {
            var appropriateJudgeId = string.Empty;
            foreach (var request in judgeRequests)
            {
                
                var isAppropriated = IsRequestAppropriated(request, fight, contestFights);

                if (isAppropriated)
                {
                    continue;
                }

                appropriateJudgeId = request.UserId;
            }

            return appropriateJudgeId;
        }

        protected abstract bool IsRequestAppropriated(ContestRequest request, Fight fight, List<Fight> contestFights);
    }

    public class InstitutionRestrictedJudgeSelector : BaseJudgeSelector
    {
        public InstitutionRestrictedJudgeSelector(IFightDurationCalculator fightDurationCalculator) : base(fightDurationCalculator)
        {
        }

        protected override bool IsRequestAppropriated(ContestRequest request, Fight fight, List<Fight> contestFights)
        {
            var fightDuration = FightDurationCalculator.CalculateFightDuration(fight.Structure.Round);

            return contestFights.Any(f =>
                       (f.FightJudgesMappings?.Any(m => m.JudgeId == request.UserId) ?? true) &&
                       f.StartDate < fight.StartDate?.Add(fightDuration) &&
                       f.StartDate > fight.StartDate?.Add(-fightDuration) &&
                       f.RedAthlete?.InstitutionId != request.InstitutionId &&
                       f.BlueAthlete?.InstitutionId != request.InstitutionId
                   ) && fight.FightJudgesMappings.Any(m => m.JudgeId == request.UserId);
        }
    }

    public class SameInstitutionAllowedJudgeSelector : BaseJudgeSelector
    {
        public SameInstitutionAllowedJudgeSelector(IFightDurationCalculator fightDurationCalculator) : base(fightDurationCalculator)
        {
        }

        protected override bool IsRequestAppropriated(ContestRequest request, Fight fight, List<Fight> contestFights)
        {
            var fightDuration = FightDurationCalculator.CalculateFightDuration(fight.Structure.Round);

            return contestFights.Any(f =>
                       (f.FightJudgesMappings?.Any(m => m.JudgeId == request.UserId) ?? true) &&
                       f.StartDate < fight.StartDate?.Add(fightDuration) &&
                       f.StartDate > fight.StartDate?.Add(-fightDuration)) &&
                   fight.FightJudgesMappings.Any(m => m.JudgeId == request.UserId);
        }
    }

    public class SameInstitutionAllowedTimeKeeperSelector : BaseJudgeSelector
    {
        public SameInstitutionAllowedTimeKeeperSelector(IFightDurationCalculator fightDurationCalculator) : base(fightDurationCalculator)
        {
        }

        protected override bool IsRequestAppropriated(ContestRequest request, Fight fight, List<Fight> contestFights)
        {
            var fightDuration = FightDurationCalculator.CalculateFightDuration(fight.Structure.Round);

            return contestFights.Any(f =>
                             f.TimeKeeperId == request.UserId &&
                             f.StartDate < fight.StartDate?.Add(fightDuration) &&
                             f.StartDate > fight.StartDate?.Add(-fightDuration)
                         ) && fight.TimeKeeperId == request.UserId;
        }
    }

    public class InstitutionRestrictedTimeKeeperSelector : BaseJudgeSelector
    {
        public InstitutionRestrictedTimeKeeperSelector(IFightDurationCalculator fightDurationCalculator) : base(fightDurationCalculator)
        {
        }

        protected override bool IsRequestAppropriated(ContestRequest request, Fight fight, List<Fight> contestFights)
        {
            var fightDuration = FightDurationCalculator.CalculateFightDuration(fight.Structure.Round);

            return contestFights.Any(f =>
                       f.TimeKeeperId == request.UserId &&
                       f.StartDate < fight.StartDate?.Add(fightDuration) &&
                       f.StartDate > fight.StartDate?.Add(-fightDuration) &&
                       f.RedAthlete?.InstitutionId != request.InstitutionId &&
                       f.BlueAthlete?.InstitutionId != request.InstitutionId
                   ) && fight.TimeKeeperId == request.UserId;
        }
    }

    public class SameInstitutionAllowedRefereeSelector : BaseJudgeSelector
    {
        public SameInstitutionAllowedRefereeSelector(IFightDurationCalculator fightDurationCalculator) : base(fightDurationCalculator)
        {
        }

        protected override bool IsRequestAppropriated(ContestRequest request, Fight fight, List<Fight> contestFights)
        {
            var fightDuration = FightDurationCalculator.CalculateFightDuration(fight.Structure.Round);

            return contestFights.Any(f =>
                       f.RefereeId == request.UserId &&
                       f.StartDate < fight.StartDate?.Add(fightDuration) &&
                       f.StartDate > fight.StartDate?.Add(-fightDuration)
                   ) && fight.TimeKeeperId == request.UserId;
        }
    }

    public class InstitutionRestrictedRefereeSelector : BaseJudgeSelector
    {
        public InstitutionRestrictedRefereeSelector(IFightDurationCalculator fightDurationCalculator) : base(fightDurationCalculator)
        {
        }

        protected override bool IsRequestAppropriated(ContestRequest request, Fight fight, List<Fight> contestFights)
        {
            var fightDuration = FightDurationCalculator.CalculateFightDuration(fight.Structure.Round);

            return contestFights.Any(f =>
                       f.RefereeId == request.UserId &&
                       f.StartDate < fight.StartDate?.Add(fightDuration) &&
                       f.StartDate > fight.StartDate?.Add(-fightDuration) &&
                       f.RedAthlete?.InstitutionId != request.InstitutionId &&
                       f.BlueAthlete?.InstitutionId != request.InstitutionId
                   ) && fight.TimeKeeperId == request.UserId;
        }
    }

}
