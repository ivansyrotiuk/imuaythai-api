using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Dictionaries;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Repositories;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/dictionaries/")]
    public class ContestTypesController : Controller
    {
        private readonly IContestTypesRepository _repository;

        public ContestTypesController(IContestTypesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("types")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var typesEntities = await _repository.GetAll();
                var types = typesEntities.Select(i => (ContestTypeDto)i).ToList();
                return Ok(types);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("types/{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var type = await _repository.Get(id) ?? new ContestType();
    
                return Ok((ContestTypeDto)type);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        [HttpPost]
        [Route("types/save")]
        public async Task<IActionResult> Save([FromBody]ContestTypeDto type)
        {
            try
            {
                ContestType typeEntity = type.Id == 0 ? new ContestType() : await _repository.Get(type.Id);
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
        [Route("types/remove")]
        public async Task<IActionResult> Remove([FromBody]ContestTypeDto type)
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