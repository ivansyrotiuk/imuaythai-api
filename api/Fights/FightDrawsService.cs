using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Fights;
using MuaythaiSportManagementSystemApi.Data;
using Microsoft.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Repositories;

namespace MuaythaiSportManagementSystemApi.Fights
{

    public class FightDrawsService : IFightDrawsService
    {
        private readonly IFightsDiagramBuilder _fightsDiagramBuilder;
        private readonly IFightersTossupper _fightersTossupper;
        private readonly IFightsRepository _fightsRepository;
        private readonly IContestRequestRepository _contestRequestRepository;
        private readonly IContestCategoriesRepository _contestCategoriesRepository;

        public FightDrawsService(IFightsRepository fightsRepository, 
            IFightsDiagramBuilder fightsDiagramBuilder, 
            IFightersTossupper fightersTossupper,
            IContestRequestRepository contestRequestRepository,
            IContestCategoriesRepository contestCategoriesRepository)
        {
            _fightsRepository = fightsRepository;
            _fightsDiagramBuilder = fightsDiagramBuilder;
            _fightersTossupper = fightersTossupper;
            _contestRequestRepository = contestRequestRepository;
            _contestCategoriesRepository = contestCategoriesRepository;
        }

        public async Task<string> GetDraws(int contestId, int categoryId)
        {
            var fights = await _fightsRepository.GetFights(contestId, categoryId);
            _fightsDiagramBuilder.GenerateFightDiagram(fights);
            string fightsDrawsJson = _fightsDiagramBuilder.ToJson();
            return fightsDrawsJson;
        }

        public async Task<string> GenerateFightsDraws(int contestId, int categoryId)
        {
            var acceptedFighterRequests = await _contestRequestRepository.GetContestAcceptedFighterRequests(contestId, categoryId);
            var fighters = acceptedFighterRequests.Select(r => r.User).ToList();
            var category = await _contestCategoriesRepository.Get(categoryId);

            FightsTree fightsTree = new FightsTree(contestId: contestId, contestCategoryId: categoryId,
                fightStructureId: category.FightStructureId, fighterCount: fighters.Count);

            _fightersTossupper.Tossup(fighters, fightsTree);

            var fights = fightsTree.ToList();

            await _fightsRepository.SaveFights(fights);

            _fightsDiagramBuilder.GenerateFightDiagram(fights);
            string fightsDrawsJson = _fightsDiagramBuilder.ToJson();
            return fightsDrawsJson;
        }

        public async Task<string> RegenerateDraws(int contestId, int categoryId)
        {
            await _fightsRepository.RemoveByContestCategory(contestId, categoryId);
            var acceptedFighterRequests = await _contestRequestRepository.GetContestAcceptedFighterRequests(contestId, categoryId);
            var fighters = acceptedFighterRequests.Select(r => r.User).ToList();
            var category = await _contestCategoriesRepository.Get(categoryId);

            FightsTree fightsTree = new FightsTree(contestId: contestId, contestCategoryId: categoryId,
                fightStructureId: category.FightStructureId, fighterCount: fighters.Count);

            _fightersTossupper.Tossup(fighters, fightsTree);

            var fights = fightsTree.ToList();

            await _fightsRepository.SaveFights(fights);

            _fightsDiagramBuilder.GenerateFightDiagram(fights);
            string fightsDrawsJson = _fightsDiagramBuilder.ToJson();
            return fightsDrawsJson;
        }

        public async Task<string> TossupFightsDraws(int contestId, int categoryId)
        {
            var acceptedFighterRequests = await _contestRequestRepository.GetContestAcceptedFighterRequests(contestId, categoryId);
            var fighters = acceptedFighterRequests.Select(r => r.User).ToList();
            var fights = await _fightsRepository.GetFights(contestId, categoryId);

            fights.ForEach(f => f.RedAthleteId = f.BlueAthleteId = null);

            FightsTree fightsTree = new FightsTree(fights);
            _fightersTossupper.Tossup(fighters, fightsTree);

            fights = fightsTree.ToList();

            await _fightsRepository.SaveFights(fights);

            _fightsDiagramBuilder.GenerateFightDiagram(fights);

            string fightsDrawsJson = _fightsDiagramBuilder.ToJson();
            return fightsDrawsJson;
        }
    }
}