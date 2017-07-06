using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Dictionaries;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Repositories;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Contest/Types")]
    public class ContestTypesController : Controller
    {
        private readonly IContestTypesRepository _repository;

        public ContestTypesController(IContestTypesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
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

        [HttpPost]
        [Route("Save")]
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
        [Route("Remove")]
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