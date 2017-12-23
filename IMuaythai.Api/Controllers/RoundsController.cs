using System;
using System.Threading.Tasks;
using IMuaythai.Dictionaries;
using IMuaythai.Models.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Authorize]
    [Route("api/dictionaries/rounds")]
    public class RoundsController : Controller
    {
        private readonly IRoundsSevice _roundsSevice;
        public RoundsController(IRoundsSevice roundsSevice)
        {
            _roundsSevice = roundsSevice;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var rounds = await _roundsSevice.GetRounds();
                return Ok(rounds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var round = await _roundsSevice.GetRound(id);
                return Ok(round);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save([FromBody]RoundModel roundModel)
        {
            try
            {
                var round = await _roundsSevice.SaveRound(roundModel);
                return Created("Add", round);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> Remove([FromBody]RoundModel round)
        {
            try
            {
                await _roundsSevice.RemoveRound(round.Id);
                return Ok(round.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}