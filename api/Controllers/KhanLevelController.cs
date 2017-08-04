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
        public async Task<IActionResult> Index()
        {
            try
            {
                var levelsEntities = await _repository.GetAll();
                var levels = levelsEntities.Select(i => (KhanLevelDto)i).ToList();
                return Ok(levels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("levels/{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var levels = await _repository.Get(id) ?? new Models.KhanLevel();
                return Ok((KhanLevelDto)levels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("levels/save")]
        public async Task<IActionResult> Save([FromBody]KhanLevelDto level)
        {
            try
            {
                Models.KhanLevel levelEntity = level.Id == 0 ? new Models.KhanLevel() : await _repository.Get(level.Id);
                levelEntity.Id = level.Id;
                levelEntity.Level = level.Level;
                levelEntity.Name = level.Name;
                await _repository.Save(levelEntity);

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
        public async Task<IActionResult> Remove([FromBody]KhanLevelDto level)
        {
            try
            {
                await _repository.Remove(level.Id);

                return Ok(level.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}