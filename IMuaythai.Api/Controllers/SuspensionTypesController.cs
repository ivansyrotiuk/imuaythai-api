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
                var types = typesEntities.Select(i => (SuspensionTypeModel)i).ToList();
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
                var type = await _repository.Get(id) ?? new SuspensionType();
                return Ok((SuspensionTypeModel)type);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("suspensions/save")]
        public async Task<IActionResult> Save([FromBody]SuspensionTypeModel type)
        {
            try
            {
                SuspensionType typeEntity = type.Id == 0 ? new SuspensionType() : await _repository.Get(type.Id);
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
        public async Task<ActionResult> Remove([FromBody]KhanLevelModel type)
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