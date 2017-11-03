using System;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Repositories.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/dictionaries/")]
    public class FightStructuresController : Controller
    {
        private readonly IFightStructuresRepository _repository;

        public FightStructuresController(IFightStructuresRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("structures")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var structuresEntities = await _repository.GetAll();
                var structures = structuresEntities.Select(i => (FightStructureModel)i).ToList();
                return Ok(structures);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("structures/{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var structure = await _repository.Get(id) ?? new FightStructure();
                var result = (FightStructureModel)structure;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("structures/save")]
        public async Task<IActionResult> Save([FromBody]FightStructureModel structure)
        {
            try
            {
                FightStructure structureEntity = structure.Id == 0 ? new FightStructure() : await _repository.Get(structure.Id);
                structureEntity.Id = structure.Id;
                structureEntity.RoundId = structure.RoundId;
                structureEntity.WeightAgeCategoryId = structure.WeightAgeCategoryId;
                await _repository.Save(structureEntity);

                structure.Id = structureEntity.Id;
                return Created("Add", structure);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("structures/remove")]
        public async Task<IActionResult> Remove([FromBody]FightStructureModel structure)
        {
            try
            {
                await _repository.Remove(structure.Id);

                return Ok(structure.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}