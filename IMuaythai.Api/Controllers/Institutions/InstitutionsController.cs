using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.Institutions;
using IMuaythai.Models.Institutions;
using IMuaythai.Models.Users;
using IMuaythai.Shared;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers.Institutions
{
    [Route("api/[controller]")]
    public class InstitutionsController : Controller
    {
        private readonly IInstitutionsService _institutionsService;
        private readonly IFileSaver _fileSaver;
        public InstitutionsController(IInstitutionsService institutionsService, IFileSaver fileSaver)
        {
            _institutionsService = institutionsService;
            _fileSaver = fileSaver;
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

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody]InstitutionUpdateModel institutionUpdateModel)
        {
            try
            {
                var imageBase64 = institutionUpdateModel.Logo?.Split(',');
                if (imageBase64?.Length > 1)
                {
                    var hostUrl = $"{Request.Scheme}://{Request.Host}";
                    institutionUpdateModel.Logo = _fileSaver.Save(hostUrl, imageBase64[1]);
                }

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
        public async Task<IActionResult> Remove([FromBody]InstitutionResponseModel institutionResponse)
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