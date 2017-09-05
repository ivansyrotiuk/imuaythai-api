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

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    public class FightsController : Controller
    {
        private readonly IFightsRepository _fightsRepository;
        private readonly IFightsDiagramBuilder _fightsDiagramBuilder;
        private readonly IContestRequestRepository _contestRequestRepository;
        private readonly IFightersTossupper _fightersTossupper;
        private readonly IContestCategoriesRepository _contestCategoriesRepository;
        private readonly IFighterMovingService _fighterMovingService;

        public FightsController(IFightsRepository fightsRepository, IFightsDiagramBuilder fightsDiagramBuilder, IContestRequestRepository contestRequestRepository, IFightersTossupper fightersTossupper, IContestCategoriesRepository contestCategoriesRepository, IFighterMovingService fighterMovingService)
        {
            _fightsRepository = fightsRepository;
            _contestRequestRepository = contestRequestRepository;
            _contestCategoriesRepository = contestCategoriesRepository;
            _fightsDiagramBuilder = fightsDiagramBuilder;
            _fightersTossupper = fightersTossupper;
            _fighterMovingService = fighterMovingService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetContestFights([FromQuery] int contestId, [FromQuery] int categoryId)
        {
            try
            {
                var fightEntities = await _fightsRepository.GetFights(contestId, categoryId);
                var fights = fightEntities.OrderByDescending(f => f.Id).Select(fight => (FightDto)fight).ToList();
                return Ok(fights);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Draws")]
        public async Task<IActionResult> GetFightsDraws([FromQuery] int contestId, [FromQuery] int categoryId)
        {
            try
            {
                var fights = await _fightsRepository.GetFights(contestId, categoryId);
                _fightsDiagramBuilder.GenerateFightDiagram(fights);
                string fightsDrawsJson = _fightsDiagramBuilder.ToJson();

                return Ok(fightsDrawsJson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Build")]
        public async Task<IActionResult> BuildFights([FromQuery] int contestId, [FromQuery] int categoryId)
        {
            try
            {
                var acceptedFighterRequests = await _contestRequestRepository.GetContestAcceptedFighterRequests(contestId, categoryId);
                var fighters = acceptedFighterRequests.Select(r => r.User).ToList();
                var category = await _contestCategoriesRepository.Get(categoryId);

                FightsTree fightsTree = new FightsTree(contestId: contestId, contestCategoryId: categoryId, 
                    fightStructureId: category.FightStructureId, fighterCount: fighters.Count);

                _fightersTossupper.Tossup(fighters, fightsTree);

                var fights = fightsTree.ToList();

                await _fightsRepository.SaveFights(fights);

                return Ok(fights);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Draws/Generate")]
        public async Task<IActionResult> GenerateFightsDraws([FromQuery] int contestId, [FromQuery] int categoryId)
        {
            try
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

                return Ok(fightsDrawsJson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Draws/Regenerate")]
        public async Task<IActionResult> RegenerateFightsDraws([FromQuery] int contestId, [FromQuery] int categoryId)
        {
            try
            {
                await _fightsRepository.RemoveByContestCategory(contestId, categoryId);
                var acceptedFighterRequests = await _contestRequestRepository.GetContestAcceptedFighterRequests(contestId, categoryId);
                var fighters = acceptedFighterRequests.Select(r => r.User).ToList();
                var category = await _contestCategoriesRepository.Get(categoryId);

                FightsTree fightsTree = new FightsTree(contestId: contestId, contestCategoryId: categoryId,
                    fightStructureId: category.FightStructureId, fighterCount: fighters.Count);

                _fightersTossupper.Tossup(fighters, fightsTree);

                fightsTree.Print();

                var fights = fightsTree.ToList();

                await _fightsRepository.SaveFights(fights);

                _fightsDiagramBuilder.GenerateFightDiagram(fights);
                string fightsDrawsJson = _fightsDiagramBuilder.ToJson();

                return Ok(fightsDrawsJson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Draws/Tossup")]
        public async Task<IActionResult> TossupFightsDraws([FromQuery] int contestId, [FromQuery] int categoryId)
        {
            try
            {
                var acceptedFighterRequests = await _contestRequestRepository.GetContestAcceptedFighterRequests(contestId, categoryId);
                var fighters = acceptedFighterRequests.Select(r => r.User).ToList();
                var fights = await _fightsRepository.GetFights(contestId, categoryId);

                fights.ForEach(f => f.RedAthleteId = f.BlueAthleteId = null );

                FightsTree fightsTree = new FightsTree(fights);
                _fightersTossupper.Tossup(fighters, fightsTree);

                fights = fightsTree.ToList();

                await _fightsRepository.SaveFights(fights);

                _fightsDiagramBuilder.GenerateFightDiagram(fights);
                string fightsDrawsJson = _fightsDiagramBuilder.ToJson();

                return Ok(fightsDrawsJson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("movefighter")]
        public async Task<IActionResult> MoveFighter([FromBody] FighterMoving fighterMoving)
        {
            try
            {
                var changedFights = await _fighterMovingService.MoveFighterToFight(fighterMoving);
                var fights = changedFights.Select(f => (FightDto)f).ToList();
                return Ok(fights);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}