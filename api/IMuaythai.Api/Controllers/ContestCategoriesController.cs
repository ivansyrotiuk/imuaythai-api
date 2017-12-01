using System;
using System.Threading.Tasks;
using IMuaythai.Dictionaries;
using IMuaythai.Models.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/dictionaries/")]
    public class ContestCategoriesController : Controller
    {
        private readonly IContestCategoriesService _categoriesService;

        public ContestCategoriesController(IContestCategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var categories = await _categoriesService.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("categories/{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var category = await _categoriesService.GetCategory(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("categories/save")]
        public async Task<IActionResult> Save([FromBody]ContestCategoryModel category)
        {
            try
            {
                var savedCategory = await _categoriesService.SaveCategory(category);
                return Created("Add", savedCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("categories/remove")]
        public async Task<IActionResult> Remove([FromBody]ContestCategoryModel category)
        {
            try
            {
                await _categoriesService.RemoveCategory(category.Id);
                return Ok(category.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}