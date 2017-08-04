using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/dictionaries/")]
    public class WeightAgeCategoriesController : Controller
    {
        private readonly IWeightAgeCategoriesRepository _repository;
        public WeightAgeCategoriesController(IWeightAgeCategoriesRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("weightcategories")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var structures = await _repository.GetAll();
                return Ok(structures);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("weightcategories/{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var result = await _repository.Get(id) ?? new WeightAgeCategory();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("weightcategories/save")]
        public async Task<IActionResult> SaveRage([FromBody]WeightAgeCategory category)
        {
            try
            {
                await _repository.Save(category);
                return Created("Add", category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("weightcategories/remove")]
        public async Task<IActionResult> RemoveRange([FromBody]WeightAgeCategory category)
        {
            try
            {
                await _repository.Remove(category.Id);

                return Ok(category.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}