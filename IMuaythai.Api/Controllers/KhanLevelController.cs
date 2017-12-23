using System;
using System.Threading.Tasks;
using IMuaythai.Dictionaries;
using IMuaythai.Models.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Route("api/dictionaries/levels")]
    public class KhanLevelsController : Controller
    {
        private readonly IKhanLevelsService _khanLevelsService;

        public KhanLevelsController(IKhanLevelsService khanLevelsService)
        {
            _khanLevelsService = khanLevelsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var levels = await _khanLevelsService.GetKhanLevels();
                return Ok(levels);
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
                var level = await _khanLevelsService.GetKhanLevel(id);
                return Ok(level);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save([FromBody]KhanLevelModel levelModel)
        {
            try
            {
                var level = await _khanLevelsService.Save(levelModel);
                return Created("Add", level);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> Remove([FromBody]KhanLevelModel level)
        {
            try
            {
                await _khanLevelsService.Remove(level.Id);
                return Ok(level.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}