using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using MuaythaiSportManagementSystemApi.Institutions.Gyms;
using MuaythaiSportManagementSystemApi.Models;
using Microsoft.AspNetCore.Identity;
using MuaythaiSportManagementSystemApi.Institutions;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class InstitutionsController : Controller
    {
        private readonly IInstitutionsRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICountriesRepository _countryRepository;

        public InstitutionsController(IInstitutionsRepository repository, UserManager<ApplicationUser> userManager, ICountriesRepository countryRepository)
        {
            _repository = repository;
            _userManager = userManager;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        [Route("Gyms")]
        public async Task<IActionResult> GetGyms()
        {
            try
            {
                var gymsEntities = await _repository.GetGyms();
                var gyms = gymsEntities.Select(i=>(GymDto)i).ToList();
                return Ok(gyms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Gyms/Country")]
        public async Task<IActionResult> GetGymsInCountry([FromQuery]int id)
        {
            try
            {
                var country = await _countryRepository.Get(id);
                if (country == null)
                {
                    return BadRequest("Country not found");
                }

                var entities = await _repository.Find(i => i.CountryId == id);
                var institutions = entities.Select(i => (InstitutionDto)i).ToList();
                return Ok(institutions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Federations/National")]
        public async Task<IActionResult> GetNationalFederations()
        {
            try
            {
                var entities = await _repository.GetNationalFederations();
                var federations = entities.Select(i => (InstitutionDto)i).ToList();
                return Ok(federations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Federations/Continental")]
        public async Task<IActionResult> GetContinentalFederations()
        {
            try
            {
                var entities = await _repository.GetContinentalFederations();
                var federations = entities.Select(i => (InstitutionDto)i).ToList();
                return Ok(federations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Federations/World")]
        public async Task<IActionResult> WorldFederations()
        {
            try
            {
                var entities = await _repository.GetWorldFederations();
                var federations = entities.Select(i => (InstitutionDto)i).ToList();
                return Ok(federations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("Federations/useravailable")]
        public async Task<IActionResult> GetUserAvailableFederations([FromQuery] string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return BadRequest("User not found");
                }

                if (user.CountryId == null)
                {
                    return BadRequest("Select country.");
                }

                var country = await _countryRepository.Get(user.CountryId.Value);

                var entities = await _repository.GetByCountry(country);
                var federations = entities.Select(i => (InstitutionDto)i).ToList();
                return Ok(federations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetInstitution([FromRoute]int id)
        {
            try
            {
                var institution = await _repository.Get(id);
                return Ok((InstitutionDto)institution);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody]InstitutionDto institution)
        {
            try
            {
                Institution entity = institution.Id == 0 ? new Institution() : await _repository.Get(institution.Id);
                entity.Id = institution.Id;
                entity.Name = institution.Name;
                entity.Address = institution.Address;
                entity.City = institution.City;
                entity.CountryId = institution.CountryId;
                entity.Email = institution.Email;
                entity.Phone = institution.Phone;
                entity.Owner = institution.Owner;
                entity.MembersCount = institution.MembersCount;
                entity.InstitutionType = institution.InstitutionType;
                await _repository.Save(entity);

                institution.Id = entity.Id;
                return Created("Add", institution);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> Remove([FromBody]GymDto institution)
        {
            try
            {
                await _repository.Remove(institution.Id);

                return Ok(institution.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}