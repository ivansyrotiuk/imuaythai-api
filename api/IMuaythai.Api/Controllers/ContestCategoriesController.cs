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
    public class ContestCategoriesController : Controller
    {
        private readonly IContestCategoriesRepository _repository;

        public ContestCategoriesController(IContestCategoriesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var categoriesEntities = await _repository.GetAll();
                var categories = categoriesEntities.Select(i => (ContestCategoryModel)i).ToList();
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
                var category = await _repository.Get(id) ?? new ContestCategory();
                var result = (ContestCategoryModel)category;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("categories/save")]
        public async Task<IActionResult> Save([FromBody]ContestCategoryModel categories)
        {
            try
            {
                ContestCategory categoriesEntity = categories.Id == 0 ? new ContestCategory() : await _repository.Get(categories.Id);
                categoriesEntity.Id = categories.Id;
                categoriesEntity.Name = categories.Name;
                categoriesEntity.ServiceBreakDuration = categories.ServiceBreakDuration;
                categoriesEntity.ContestTypePointsId = categories.ContestTypePointsId;
                categoriesEntity.FightStructureId = categories.FightStructureId;
                await _repository.Save(categoriesEntity);

                categories.Id = categoriesEntity.Id;
                return Created("Add", categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("categories/remove")]
        public async Task<IActionResult> Remove([FromBody]ContestCategoryModel categories)
        {
            try
            {
                await _repository.Remove(categories.Id);

                return Ok(categories.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}