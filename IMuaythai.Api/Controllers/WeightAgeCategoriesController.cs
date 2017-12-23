using System;
using System.Threading.Tasks;
using IMuaythai.Dictionaries;
using IMuaythai.Models.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/dictionaries/weightcategories")]
    public class WeightAgeCategoriesController : Controller
    {
        private readonly IWeightAgeCategoriesService _service;
        public WeightAgeCategoriesController(IWeightAgeCategoriesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var categories = await _service.GetWeightAgeCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var category = await _service.GetWeightAgeCategory(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save([FromBody]WeightAgeCategoryModel categoryModel)
        {
            try
            {
                WeightAgeCategoryModel category = await _service.Save(categoryModel);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> Remove([FromBody]WeightAgeCategoryModel category)
        {
            try
            {
                await _service.Remove(category.Id);
                return Ok(category.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}