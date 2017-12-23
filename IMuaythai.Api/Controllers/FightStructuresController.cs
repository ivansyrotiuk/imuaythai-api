using System;
using System.Threading.Tasks;
using IMuaythai.Dictionaries;
using IMuaythai.Models.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Route("api/dictionaries/structures")]
    public class FightStructuresController : Controller
    {
        private readonly IFightStructuresService _fightStructuresService;

        public FightStructuresController(IFightStructuresService fightStructuresService)
        {
            _fightStructuresService = fightStructuresService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var structures = await _fightStructuresService.GetFightStructures();
                return Ok(structures);
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
                var structure = await _fightStructuresService.GetFightStructure(id);
                return Ok(structure);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save([FromBody]FightStructureModel structureModel)
        {
            try
            {
                var structure = await _fightStructuresService.SaveFightStructure(structureModel);
                return Created("Add", structure);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> Remove([FromBody]FightStructureModel structure)
        {
            try
            {
                await _fightStructuresService.RemoveFightStructure(structure.Id);
                return Ok(structure.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}