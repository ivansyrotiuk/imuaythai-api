using System;
using System.Threading.Tasks;
using IMuaythai.Dictionaries;
using IMuaythai.Models.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/dictionaries/points")]
    public class ContestPointsController : Controller
    {
        private readonly IContestTypePointsService _contestTypePointsService;

        public ContestPointsController(IContestTypePointsService contestTypePointsService)
        {
            _contestTypePointsService = contestTypePointsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var points = await _contestTypePointsService.GetAllContestTypePoints();
                return Ok(points);
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
                var points = await _contestTypePointsService.GetContestTypePoints(id);
                return Ok(points);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("save")]
        public async  Task<IActionResult> Save([FromBody]ContestPointsModel points)
        {
            try
            {
                var savedPoints = await _contestTypePointsService.SaveContestTypePoints(points);
                return Created("Add", savedPoints);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> Remove([FromBody]ContestPointsModel points)
        {
            try
            {
                await _contestTypePointsService.RemoveContestTypePoints(points.Id);
                return Ok(points.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}