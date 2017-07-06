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
    [Route("api/ContestRange")]
    public class ContestRangesController : Controller
    {
        private readonly IContestRangesRepository _repository;

        public ContestRangesController(IContestRangesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
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

        [HttpPost]
        [Route("Save")]
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
        [Route("Remove")]
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