using System;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.Fights;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class FightsController : Controller
    {
        private readonly IFightsService _fightsService;
        private readonly IFightDrawsService _drawsService;

        public FightsController(IFightsService fightsService, IFightDrawsService drawsService)
        {
            _fightsService = fightsService;
            _drawsService = drawsService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetContestFights([FromQuery] int contestId, [FromQuery] int categoryId)
        {
            try
            {
                var fights = categoryId == 0 
                    ? await _fightsService.GetFights(contestId)
                    : await _fightsService.GetFights(contestId, categoryId);

                return Ok(fights.OrderBy(f => f.StartDate));
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
                var fights = await _fightsService.BuildFights(contestId, categoryId);
                return Ok(fights);
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
                var fights = await _fightsService.MoveFighter(fighterMoving);
                return Ok(fights);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("movefight")]
        public async Task<IActionResult> MoveFighter([FromBody] FightMoving fightMoving)
        {
            try
            {
                var fights = await _fightsService.MoveFight(fightMoving);
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
                var fightsDrawsJson = await _drawsService.GetDraws(contestId, categoryId);
                return Ok(fightsDrawsJson);
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
                var fightsDrawsJson = await _drawsService.GenerateFightsDraws(contestId, categoryId);
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
                var fightsDrawsJson = await _drawsService.RegenerateDraws(contestId, categoryId);
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
                var fightsDrawsJson = await _drawsService.TossupFightsDraws(contestId, categoryId);
                return Ok(fightsDrawsJson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Schedule")]
        public async Task<IActionResult> ScheduleFights([FromQuery] int contestId)
        {
            try
            {
                var fights = await _fightsService.ScheduleFights(contestId);
                return Ok(fights);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Judges/Tossup")]
        public async Task<IActionResult> TossupJudges([FromQuery] int contestId)
        {
            try
            {
                await _fightsService.ClearContestJudgeMappings(contestId);
                var fights = await _fightsService.TossupJudges(contestId);

                return Ok(fights);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFight([FromRoute] int id)
        {
            try
            {
                var fight = await _fightsService.GetFight(id);
                return Ok(fight);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}