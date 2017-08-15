using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using MuaythaiSportManagementSystemApi.Dictionaries;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Controllers
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
                var categories = categoriesEntities.Select(i => (ContestCategoryDto)i).ToList();
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
                var categories = await _repository.Get(id) ?? new ContestCategory();
                var result = (ContestCategoryDto)categories;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("categories/save")]
        public async Task<IActionResult> Save([FromBody]ContestCategoryDto categories)
        {
            try
            {
                ContestCategory categoriesEntity = categories.Id == 0 ? new ContestCategory() : await _repository.Get(categories.Id);
                categoriesEntity.Id = categories.Id;
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
        public async Task<IActionResult> Remove([FromBody]ContestCategoryDto categories)
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