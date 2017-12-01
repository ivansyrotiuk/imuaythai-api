using System;
using System.Threading.Tasks;
using IMuaythai.Dictionaries;
using IMuaythai.Models.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Route("api/dictionaries/types")]
    public class ContestTypesController : Controller
    {
        private readonly IContestTypesService _contestTypesService;

        public ContestTypesController(IContestTypesService contestTypesService)
        {
            _contestTypesService = contestTypesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var types = await _contestTypesService.GetContestTypes();
                return Ok(types);
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
                var type = await _contestTypesService.GetContestType(id);
                return Ok(type);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save([FromBody]ContestTypeModel typeModel)
        {
            try
            {
                var type = await _contestTypesService.SaveContestType(typeModel);
                return Created("Add", type);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> Remove([FromBody]ContestTypeModel type)
        {
            try
            {
                await _contestTypesService.RemoveContestType(type.Id);
                return Ok(type.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}