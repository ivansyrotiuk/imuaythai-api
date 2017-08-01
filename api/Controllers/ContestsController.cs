using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Contests;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    public class ContestsController : Controller
    {
        private readonly IContestRepository _repository;

        public ContestsController(IContestRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var contestsEntities = await _repository.GetAll();
                var contests = contestsEntities.Select(c => (ContestDto)c).ToList();
                return Ok(contests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetContest([FromRoute]int id)
        {
            try
            {
                var contestEntity = await _repository.Get(id);
                var contest = (ContestDto)contestEntity;
                return Ok(contest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveContest([FromBody]ContestDto contest)
        {
            try
            {
                Contest contestEntity = contest.Id == 0 ? new Contest() : await _repository.Get(contest.Id);
                contestEntity.Id = contest.Id;
                contestEntity.Name = contest.Name;
                contestEntity.Date = contest.Date;
                contestEntity.Address = contest.Address;
                contestEntity.Duration = contest.Duration;
                contestEntity.RingsCount = contest.RingsCount;
                contestEntity.City = contest.City;
                contestEntity.CountryId = contest.CountryId;
                contestEntity.Website = contest.Website;
                contestEntity.Facebook = contest.Facebook;
                contestEntity.VK = contest.VK;
                contestEntity.Twitter = contest.Twitter;
                contestEntity.Instagram = contest.Instagram;
                contestEntity.EndRegistrationDate = contest.EndRegistrationDate;
                contestEntity.ContestRangeId = contest.ContestRangeId;
                contestEntity.ContestTypeId = contest.ContestTypeId;
               
                await _repository.Save(contestEntity);
                await _repository.SaveCategoryMappings(contestEntity, contest.ContestCategories);

                return Created("Add", contest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> RemoveContest([FromBody]ContestDto contest)
        {
            try
            {
                await _repository.Remove(contest.Id);

                return Ok(contest.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}