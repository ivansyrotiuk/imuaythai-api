using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/dictionaries/")]
    public class RoundsController : Controller
    {
        private readonly IRoundsRepository _repository;
        public RoundsController(IRoundsRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("rounds")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var rounds = await _repository.GetAll();
                return Ok(rounds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("rounds/{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var result = await _repository.Get(id) ?? new Round();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("rounds/save")]
        public async Task<IActionResult> SaveRage([FromBody]Round round)
        {
            try
            {
                await _repository.Save(round);
                return Created("Add", round);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("rounds/remove")]
        public async Task<IActionResult> RemoveRange([FromBody]WeightAgeCategory round)
        {
            try
            {
                await _repository.Remove(round.Id);

                return Ok(round.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}