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
    public class SuspensionTypesController : Controller
    {
        private readonly ISuspensionTypesRepository _repository;

        public SuspensionTypesController(ISuspensionTypesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("suspensions")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var typesEntities = await _repository.GetAll();
                var types = typesEntities.Select(i => (SuspensionTypeDto)i).ToList();
                return Ok(types);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("suspensions/{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var type = await _repository.Get(id) ?? new Models.SuspensionType();
                return Ok((SuspensionTypeDto)type);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("suspensions/save")]
        public async Task<IActionResult> Save([FromBody]SuspensionTypeDto type)
        {
            try
            {
                Models.SuspensionType typeEntity = type.Id == 0 ? new Models.SuspensionType() : await _repository.Get(type.Id);
                typeEntity.Id = type.Id;
                typeEntity.Name = type.Name;
                await _repository.Save(typeEntity);

                type.Id = typeEntity.Id;
                return Created("Add", type);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("suspensions/remove")]
        public async Task<ActionResult> Remove([FromBody]KhanLevelDto type)
        {
            try
            {
                await _repository.Remove(type.Id);

                return Ok(type.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}