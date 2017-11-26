using System;
using System.Threading.Tasks;
using IMuaythai.Dictionaries;
using IMuaythai.Models.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/dictionaries/ranges")]
    public class ContestRangesController : Controller
    {
        private readonly IContestRangesService _contestRangesService;

        public ContestRangesController(IContestRangesService contestRangesService)
        {
            _contestRangesService = contestRangesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var ranges = await _contestRangesService.GetContestRanges();
                return Ok(ranges);
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
                var range = await _contestRangesService.GetContestRange(id);
                return Ok(range);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save([FromBody]ContestRangeModel range)
        {
            try
            {
                var savedContestRange = await _contestRangesService.SaveContestRange(range);
                return Created("Add", savedContestRange);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> Remove([FromBody]ContestRangeModel range)
        {
            try
            {
                await _contestRangesService.RemoveContestRange(range.Id);
                return Ok(range.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}