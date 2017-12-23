using System;
using System.Threading.Tasks;
using IMuaythai.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Route("api/[controller]")]
    public class LocationsController : Controller
    {
        private readonly ICountriesService _countriesService;

        public LocationsController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet]
        [Route("countries")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var countries = await _countriesService.GetCountries();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
