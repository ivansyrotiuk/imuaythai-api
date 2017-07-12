using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using MuaythaiSportManagementSystemApi.Dictionaries;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/contest/")]
    public class ContestPointsController : Controller
    {
        private readonly IContestTypePointsRepository _repository;

        public ContestPointsController(IContestTypePointsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("points")]
        public IActionResult Index()
        {
            try
            {
                var points = _repository.GetAll().Select(i => (ContestPointsDto)i).ToList();
                return Ok(points);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("points/{id}")]
        public IActionResult Index([FromRoute] int id)
        {
            try
            {
                var points = _repository.Get(id) ?? new ContestTypePoints();
                return Ok((ContestPointsDto)points);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("points/save")]
        public IActionResult SaveRage([FromBody]ContestPointsDto points)
        {
            try
            {
                ContestTypePoints pointsEntity = points.Id == 0 ? new ContestTypePoints() : _repository.Get(points.Id);
                pointsEntity.Id = points.Id;
                pointsEntity.Points = points.Points;
                pointsEntity.ContestRangeId = points.ContestRange.Id;
                pointsEntity.ContestTypeId = points.ContestType.Id;
                _repository.Save(pointsEntity);

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