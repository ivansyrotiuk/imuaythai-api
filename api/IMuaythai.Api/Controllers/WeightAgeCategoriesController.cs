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
                var categories = await _repository.GetAll();
                return Ok(categories.Select(c=>(WeightAgeCategoryModel)c).ToList());
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
                return Ok((WeightAgeCategoryModel)result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("weightcategories/save")]
        public async Task<IActionResult> Save([FromBody]WeightAgeCategoryModel category)
        {
            try
            {
                WeightAgeCategory categoryEntity = category.Id == 0 ? new WeightAgeCategory() : await _repository.Get(category.Id);
                categoryEntity.Id = category.Id;
                categoryEntity.Name = category.Name;
                categoryEntity.MaxAge = category.MaxAge;
                categoryEntity.MinAge = category.MinAge;
                categoryEntity.MinWeight = category.MinWeight;
                categoryEntity.MaxWeight = category.MaxWeight;
                categoryEntity.Gender = category.Gender;

                await _repository.Save(categoryEntity);

                category.Id = categoryEntity.Id;
                return Created("Add", category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("weightcategories/remove")]
        public async Task<IActionResult> Remove([FromBody]WeightAgeCategoryModel category)
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