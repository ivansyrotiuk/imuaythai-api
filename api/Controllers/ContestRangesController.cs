using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Dictionaries;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Repositories;


namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/dictionaries/")]
    public class ContestRangesController : Controller
    {
        private readonly IContestRangesRepository _repository;

        public ContestRangesController(IContestRangesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("ranges")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var rangesEntities = await _repository.GetAll();
                var ranges = rangesEntities.Select(i => (ContestRangeDto)i).ToList();
                return Ok(ranges);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ranges/{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var range = await _repository.Get(id) ?? new ContestRange();
                return Ok((ContestRangeDto)range);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("ranges/save")]
        public async Task<IActionResult> SaveRage([FromBody]ContestRangeDto range)
        {
            try
            {
                ContestRange rangeEntity = range.Id == 0 ? new ContestRange() : await _repository.Get(range.Id);
                rangeEntity.Id = range.Id;
                rangeEntity.Name = range.Name;

                await _repository.Save(rangeEntity);

                range.Id = rangeEntity.Id;
                return Created("Add", range);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("ranges/remove")]
        public async Task<IActionResult> RemoveRange([FromBody]ContestRangeDto range)
        {
            try
            {
                await _repository.Remove(range.Id);

                return Ok(range.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}