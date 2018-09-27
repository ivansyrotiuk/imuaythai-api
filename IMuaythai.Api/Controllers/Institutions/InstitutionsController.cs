using System;
using System.Threading.Tasks;
using IMuaythai.Institutions;
using IMuaythai.Models.Institutions;
using IMuaythai.Shared;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers.Institutions
{
    [Route("api/[controller]")]
    public class InstitutionsController : Controller
    {
        private readonly IInstitutionsService _institutionsService;
        private readonly IFilesService _filesService;
        public InstitutionsController(IInstitutionsService institutionsService, IFilesService filesSarvice)
        {
            _institutionsService = institutionsService;
            _filesService = filesSarvice;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetInstitution([FromRoute]int id)
        {
            try
            {
                var institution = await _institutionsService.Get(id);
                return Ok(institution);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Members")]
        public async Task<IActionResult> GetMembers([FromQuery] int institutionId)
        {
            try
            {
                var members = await _institutionsService.GetMembers(institutionId);

                return Ok(members);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Gyms")]
        public async Task<IActionResult> GetGyms([FromQuery] int institutionId)
        {
            try
            {
                var gyms = await _institutionsService.GetGyms(institutionId);

                return Ok(gyms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody]InstitutionUpdateModel institutionUpdateModel)
        {
            try
            {
                institutionUpdateModel.Logo = _filesService.UploadFile(institutionUpdateModel.Logo) ?? institutionUpdateModel.Logo;
                var institutionResponse = await _institutionsService.Save(institutionUpdateModel);
                return Created("Add", institutionResponse);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> Remove([FromBody]InstitutionRemoveModel institutionResponse)
        {
            try
            {
                await _institutionsService.Remove(institutionResponse.Id);

                return Ok(institutionResponse.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}