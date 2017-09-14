using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class FightController : Controller
    {

        private readonly IFightRepository _repository;
        public FightController(IFightRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("get/{contestId}/{ringId}")]
        public async Task<IActionResult> GetFightsToRing([FromRoute] int contestId, string ringId)
        {
            var fights = await _repository.Find(f => f.Ring == ringId
            && f.ContestId == contestId
            && !string.IsNullOrEmpty(f.BlueAthleteId)
            && !string.IsNullOrEmpty(f.RedAthleteId)
            && string.IsNullOrEmpty(f.WinnerId));

            if (fights == null || fights.Count == 0)
                return BadRequest("No fights found");

            return Ok(fights);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetFight([FromRoute] int id)
        {
            var fight = await _repository.Get(id);

            if (fight == null)
                return BadRequest("No fight found");

            return Ok(fight);

        }
    }
}