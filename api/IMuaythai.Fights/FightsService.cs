using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Contests;
using IMuaythai.Repositories;
using IMuaythai.Repositories.Contests;
using IMuaythai.Repositories.Dictionaries;
using MoreLinq;

namespace IMuaythai.Fights
{
    public class FightsService : IFightsService
    {
        private readonly IFightsIndexer _fightsIndexer;
        private readonly IJudgesTossuper _judgesTossuper;
        private readonly IFightsRepository _fightsRepository;
        private readonly IContestRepository _contestRepository;
        private readonly IFightersTossupper _fightersTossupper;
        private readonly IFighterMovingService _fighterMovingService;
        private readonly IContestRingsRepository _contestRingsRepository;
        private readonly IContestRequestRepository _contestRequestRepository;
        private readonly IContestCategoriesRepository _contestCategoriesRepository;
        private readonly IContestCategoryMappingsRepository _contestCategoryMappingsRepository;

        public FightsService(
            IFightsIndexer fightsIndexer,
            IJudgesTossuper judgesTossuper,
            IFightsRepository fightsRepository,
            IFightersTossupper fightersTossupper,
            IContestRepository contestRepository,
            IFighterMovingService fighterMovingService,
            IContestRingsRepository contestRingsRepository,
            IContestRequestRepository contestRequestRepository,
            IContestCategoriesRepository contestCategoriesRepository,
            IContestCategoryMappingsRepository contestCategoryMappingsRepository)
        {
            _fightsIndexer = fightsIndexer;
            _judgesTossuper = judgesTossuper;
            _fightsRepository = fightsRepository;
            _contestRepository = contestRepository;
            _fightersTossupper = fightersTossupper;
            _fighterMovingService = fighterMovingService;
            _contestRingsRepository = contestRingsRepository;
            _contestRequestRepository = contestRequestRepository;
            _contestCategoriesRepository = contestCategoriesRepository;
            _contestCategoryMappingsRepository = contestCategoryMappingsRepository;
        }

        public Task<Fight> GetFight(int id)
        {
            return _fightsRepository.Get(id);
        }

        public Task<List<Fight>> GetFights(int contestId)
        {
            return _fightsRepository.GetFights(contestId);
        }

        public Task<List<Fight>> GetFights(int contestId, int categoryId)
        {
            return _fightsRepository.GetFights(contestId, categoryId);
        }

        public async Task<List<Fight>> BuildFights(int contestId)
        {
            var acceptedFighterRequests = await _contestRequestRepository.GetContestAcceptedFighterRequests(contestId);
            var fighters = acceptedFighterRequests.Select(r => r.User).ToList();

            var categories = acceptedFighterRequests.Select(r => r.ContestCategory).Distinct().ToList();

            List<Fight> fights = new List<Fight>();

            foreach(var category in categories)
            {
                FightsTree fightsTree = new FightsTree(contestId: contestId, contestCategoryId: category.Id,
                    fightStructureId: category.FightStructureId, fighterCount: fighters.Count);

                _fightersTossupper.Tossup(fighters, fightsTree);

                var categoryFights = fightsTree.ToList();
                fights.AddRange(categoryFights);
            }

            return fights;
        }

        public async Task<List<Fight>> BuildFights(int contestId, int categoryId)
        {
            var acceptedFighterRequests = await _contestRequestRepository.GetContestAcceptedFighterRequests(contestId, categoryId);
            var fighters = acceptedFighterRequests.Select(r => r.User).ToList();
            var category = await _contestCategoriesRepository.Get(categoryId);

            FightsTree fightsTree = new FightsTree(contestId: contestId, contestCategoryId: categoryId,
                fightStructureId: category.FightStructureId, fighterCount: fighters.Count);

            _fightersTossupper.Tossup(fighters, fightsTree);

            var fights = fightsTree.ToList();

            return fights;
        }

        public async Task<List<Fight>> MoveFighter(FighterMoving fighterMoving)
        {
            var changedFights = await _fighterMovingService.MoveFighterToFight(fighterMoving);
            return changedFights;
        }

        public async Task<List<Fight>> MoveFight(FightMoving fightMoving)
        {
            var fight = await _fightsRepository.Get(fightMoving.SourceFightId);
            var fights = await _fightsRepository.GetFights(fight.ContestId);

            var sourceFight = fights.First(f => f.Id == fightMoving.SourceFightId);
            var targetFight = fights.First(f => f.Id == fightMoving.TargetFightId);

            DateTime? startTime = sourceFight.StartDate;
            sourceFight.StartDate = targetFight.StartDate;
            targetFight.StartDate = startTime;

            fights = fights.Where(f => f.Ring == fight.Ring).OrderBy(f => f.StartDate).ToList();
            for (int i = 0; i < fights.Count; i++)
            {
                fights[i].StartNumber = i + 1;
            }

            await _fightsRepository.SaveFights(fights);
            return fights;
        }

        public async Task<List<Fight>> ScheduleFights(int contestId)
        {
            var contestFights = await _fightsRepository.GetFights(contestId);
            var contestCategories = await _contestCategoryMappingsRepository.GetByContest(contestId);
            var indexedContestFights = contestFights
                .GroupBy(fight => fight.ContestCategoryId)
                .OrderByDescending(group => group.Count())
                .ToDictionary(group => group.Key,
                    group => _fightsIndexer
                        .CreateIndex(group.ToList())
                        .OrderByDescending(fight => fight.Fight.Id)
                        .ToLookup(f => f.DrawDeepLevel, f => f));

            int startNumber = 1;
            int maxDeep = indexedContestFights.Max(fights => fights.Value.Max(index => index.Key));
            for(int deep = maxDeep; deep > 0; deep--)
            {
                foreach(var categoryFights in indexedContestFights)
                {
                    if (!categoryFights.Value.Contains(deep))
                    {
                        continue;
                    }

                    var fights = categoryFights.Value[deep];
                    foreach(var fight in fights)
                    {
                        fight.Index = startNumber;
                        startNumber++;
                    }
                }
            }

            var contest = await _contestRepository.Get(contestId);
            var ringsEnties = await _contestRingsRepository.GetByContest(contestId);
            var rings = ringsEnties.Select(ring => (RingAvailabilityModel)ring).ToList();
            var indexedFights = indexedContestFights.SelectMany(index => index.Value.SelectMany(f => f).ToList()).OrderBy(f => f.Index).ToList();
            foreach (var fight in indexedFights)
            {
                var category = contestCategories.First(c => c.ContestCategoryId == fight.Fight.ContestCategoryId);

                var round = category.ContestCategory.FightStructure.Round;
                int fightTime = (round.Duration + round.BreakDuration) * round.RoundsCount + contest.WaiKhruTime;

                var ring = rings.Where(r => r.From < r.To).MinBy(r => r.From);

                fight.Fight.StartDate = ring.From;
                fight.Fight.Ring = ring.Name;
                ring.From = ring.From.AddSeconds(fightTime);
            }


            foreach(var cf in indexedContestFights)
            {
                Console.WriteLine(cf.GetHashCode());
                foreach (var deepFights in cf.Value)
                {
                    Console.WriteLine("Deep: " + deepFights.Key);

                    foreach (IndexedFight fight in deepFights.ToList())
                    {
                        Console.WriteLine($"Index: {fight.Index}   Fight:{fight.Fight.Id}   Red:{fight.Fight.RedAthlete?.FirstName} {fight.Fight.RedAthlete?.Surname}  VS   Blue:{fight.Fight.BlueAthlete?.FirstName} {fight.Fight.BlueAthlete?.Surname} at: {fight.Fight.StartDate} on {fight.Fight.Ring}");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            var scheduledFights = indexedContestFights.SelectMany(index => index.Value.SelectMany(fights => fights.Select(f => f.Fight))).ToList();
            int fightStartNumber = 1;
            scheduledFights.ForEach(fight =>
            {
                fight.StartNumber = fightStartNumber++;
            });

            return scheduledFights;
        }

        public async Task<List<Fight>> Save(List<Fight> fights)
        {
            await _fightsRepository.SaveFights(fights);
            return fights;
        }

        public async Task<List<Fight>> TossupJudges(int contestId)
        {
            var judgesRequests = await _contestRequestRepository.GetByContest(contestId, ContestRoleType.Judge);
            var fights = await _fightsRepository.GetFights(contestId);
            _judgesTossuper.Tossup(judgesRequests, fights);
            return fights;
        }

        public async Task ClearContestJudgeMappings(int contestId)
        {
            var fights = await _fightsRepository.GetFights(contestId);
            await _fightsRepository.ClearJudgeMappings(fights);
        }
    }
}