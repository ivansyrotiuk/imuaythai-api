using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using MuaythaiSportManagementSystemApi.Institutions.Gyms;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Gyms")]
    public class GymsController : Controller
    {
        private readonly IInstitutionRepository _repository;

        public GymsController(IInstitutionRepository repository)
        {
            _repository = new GymsRepository(repository);
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var gyms = _repository.GetAll().ToList();
                return Ok(gyms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult SaveGym([FromBody]GymDto gym)
        {
            try
            {
                Institution gymEntity = gym.Id == 0 ? new Institution() : _repository.Get(gym.Id);
                gymEntity.Id = gym.Id;
                gymEntity.Name = gym.Name;
                gymEntity.Countryid = 1;

                _repository.Save(gymEntity);

                gym.Id = gymEntity.Id;
                return Created("Add", gym);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Remove")]
        public IActionResult RemoveGym([FromBody]GymDto gym)
        {
            try
            {
                _repository.Remove(gym.Id);

                return Ok(gym.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}