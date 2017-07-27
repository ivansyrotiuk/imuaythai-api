using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    public class ContestController : Controller
    {
        private readonly IContestRepository _repository;

        public ContestController(IContestRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var contests = await _repository.GetAll();
              
                return Ok(contests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("contest/{id}")]
        public async Task<IActionResult> GetContest([FromRoute]int id)
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
        public async Task<IActionResult> SaveContest([FromBody]GymDto gym)
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
            catch (Exception ex)
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