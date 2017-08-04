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
                var structures = structuresEntities.Select(i => (FightStructureDto)i).ToList();
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
                var result = (FightStructureDto)structure;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("structures/save")]
        public async Task<IActionResult> SaveRage([FromBody]FightStructureDto structure)
        {
            try
            {
                FightStructure structureEntity = structure.Id == 0 ? new FightStructure() : await _repository.Get(structure.Id);
                structureEntity.Id = structure.Id;
                structureEntity.Round = structure.Round;
                structureEntity.RoundId = structure.Round.Id;
                structureEntity.WeightAgeCategory = structure.WeightAgeCategory;
                structureEntity.WeightAgeCategoryId = structure.WeightAgeCategory.Id;
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
        public async Task<IActionResult> RemoveRange([FromBody]FightStructureDto structure)
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