using System;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Repositories.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/dictionaries/")]
    public class ContestPointsController : Controller
    {
        private readonly IContestTypePointsRepository _repository;

        public ContestPointsController(IContestTypePointsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("points")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var pointsEntities = await _repository.GetAll();
                var points = pointsEntities.Select(i => (ContestPointsDto)i).ToList();
                return Ok(points);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("points/{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var points = await _repository.Get(id) ?? new ContestTypePoints();
                var result = (ContestPointsDto)points;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("points/save")]
        public async  Task<IActionResult> Save([FromBody]ContestPointsDto points)
        {
            try
            {
                ContestTypePoints pointsEntity = points.Id == 0 ? new ContestTypePoints() : await _repository.Get(points.Id);
                pointsEntity.Id = points.Id;
                pointsEntity.Points = points.Points;
                pointsEntity.ContestRangeId = points.ContestRangeId;
                pointsEntity.ContestTypeId = points.ContestTypeId;
                await _repository.Save(pointsEntity);

                points.Id = pointsEntity.Id;
                return Created("Add", points);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("points/remove")]
        public async Task<IActionResult> Remove([FromBody]ContestPointsDto points)
        {
            try
            {
                await _repository.Remove(points.Id);

                return Ok(points.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}