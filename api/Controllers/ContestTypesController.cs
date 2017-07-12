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
    [Route("api/contest/")]
    public class ContestTypesController : Controller
    {
        private readonly IContestTypesRepository _repository;

        public ContestTypesController(IContestTypesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("types")]
        public IActionResult Index()
        {
            try
            {
                var types = _repository.GetAll().Select(i => (ContestTypeDto)i).ToList();
                return Ok(types);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("types/{id}")]
        public IActionResult Index([FromRoute] int id)
        {
            try
            {
                var type = _repository.Get(id) ?? new ContestType();
    
                return Ok((ContestTypeDto)type);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        [HttpPost]
        [Route("types/save")]
        public IActionResult SaveType([FromBody]ContestTypeDto type)
        {
            try
            {
                ContestType typeEntity = type.Id == 0 ? new ContestType() : _repository.Get(type.Id);
                typeEntity.Id = type.Id;
                typeEntity.Name = type.Name;

                _repository.Save(typeEntity);

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
        public IActionResult RemoveType([FromBody]ContestTypeDto type)
        {
            try
            {
                _repository.Remove(type.Id);

                return Ok(type.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}