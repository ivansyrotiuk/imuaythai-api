using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using MuaythaiSportManagementSystemApi.Institutions.Gyms;
using MuaythaiSportManagementSystemApi.Models;
using System.Threading;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Gyms")]
    public class GymsController : Controller
    {
        private readonly IInstitutionsRepository _repository;

        public GymsController(IInstitutionsRepository repository)
        {
            _repository = new GymsRepository(repository);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var gymsEntities = await _repository.GetAll();
                var gyms = gymsEntities.Select(i=>(GymDto)i).ToList();
                return Ok(gyms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Gym/{id}")]
        public async Task<IActionResult> GetGym([FromRoute]int id)
        {
            try
            {
                var gym = await _repository.Get(id);
                return Ok((GymDto)gym);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveGym([FromBody]GymDto gym)
        {
            try
            {
                Institution gymEntity = gym.Id == 0 ? new Institution() : await _repository.Get(gym.Id);
                gymEntity.Id = gym.Id;
                gymEntity.Name = gym.Name;
                gymEntity.Address = gym.Address;
                gymEntity.City = gym.City;
                gymEntity.CountryId = 958;

                await _repository.Save(gymEntity);

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
        public async Task<IActionResult> RemoveGym([FromBody]GymDto gym)
        {
            try
            {
                await _repository.Remove(gym.Id);

                return Ok(gym.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}