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
                var levels = await _repository.Get(id) ?? new KhanLevel();
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
                KhanLevel levelEntity = level.Id == 0 ? new KhanLevel() : await _repository.Get(level.Id);
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