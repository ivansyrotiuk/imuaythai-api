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
        public IActionResult Index()
        {
            try
            {
                var ranges = _repository.GetAll().Select(i => (ContestRangeDto)i).ToList();
                return Ok(ranges);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ranges/{id}")]
        public IActionResult Index([FromRoute] int id)
        {
            try
            {
                var range = _repository.Get(id) ?? new ContestRange();
                return Ok((ContestRangeDto)range);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("ranges/save")]
        public IActionResult SaveRage([FromBody]ContestRangeDto range)
        {
            try
            {
                ContestRange rangeEntity = range.Id == 0 ? new ContestRange() : _repository.Get(range.Id);
                rangeEntity.Id = range.Id;
                rangeEntity.Name = range.Name;

                _repository.Save(rangeEntity);

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
        public IActionResult RemoveRange([FromBody]ContestRangeDto range)
        {
            try
            {
                _repository.Remove(range.Id);

                return Ok(range.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}