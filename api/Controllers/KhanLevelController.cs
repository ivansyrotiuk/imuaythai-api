using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using MuaythaiSportManagementSystemApi.Dictionaries;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/dictionaries/")]
    public class KhanLevelsController : Controller
    {
        private readonly IKhanLevelsRepository _repository;

        public KhanLevelsController(IKhanLevelsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("levels")]
        public IActionResult Index()
        {
            try
            {
                var levels = _repository.GetAll().Select(i => (KhanLevelDto)i).ToList();
                return Ok(levels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("levels/{id}")]
        public IActionResult Index([FromRoute] int id)
        {
            try
            {
                var levels = _repository.Get(id) ?? new Models.KhanLevel();
                return Ok((KhanLevelDto)levels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("levels/save")]
        public IActionResult SaveRage([FromBody]KhanLevelDto level)
        {
            try
            {
                Models.KhanLevel levelEntity = level.Id == 0 ? new Models.KhanLevel() : _repository.Get(level.Id);
                levelEntity.Id = level.Id;
                levelEntity.Level = level.Level;
                levelEntity.Name = level.Name;
                _repository.Save(levelEntity);

                level.Id = levelEntity.Id;
                return Created("Add", level);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("levels/remove")]
        public IActionResult RemoveRange([FromBody]KhanLevelDto level)
        {
            try
            {
                _repository.Remove(level.Id);

                return Ok(level.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}