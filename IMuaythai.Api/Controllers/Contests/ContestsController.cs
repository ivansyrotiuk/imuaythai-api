using System;
using System.Threading.Tasks;
using IMuaythai.Contests;
using IMuaythai.Models.Contests;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers.Contests
{ 
    //[Authorize]
    [Route("api/[controller]")]
    public class ContestsController : Controller
    {
        private readonly IContestsService _contestsService;
     
        public ContestsController(IContestsService contestsService)
        {
            _contestsService = contestsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var contests = await _contestsService.GetContests();
                return Ok(contests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetContest([FromRoute]int id)
        {
            try
            {
                var contest = await _contestsService.GetContest(id);
                return Ok(contest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveContest([FromBody]ContestModel contest)
        {
            try
            {
                var savedContest = await _contestsService.SaveContest(contest);
                return Created("Add", savedContest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> RemoveContest([FromBody]ContestModel contest)
        {
            try
            {
                await _contestsService.RemoveContest(contest.Id);
                return Ok(contest.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetContestCategoriesWithFighters([FromQuery] int contestId)
        {
            try
            {
                var contestCategoriesWithFighters = await _contestsService.GetContestCategories(contestId);
                return Ok(contestCategoriesWithFighters);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}