using System;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Repositories.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
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
                var ranges = rangesEntities.Select(i => (ContestRangeModel)i).ToList();
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
                return Ok((ContestRangeModel)range);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("ranges/save")]
        public async Task<IActionResult> Save([FromBody]ContestRangeModel range)
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
        public async Task<IActionResult> Remove([FromBody]ContestRangeModel range)
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