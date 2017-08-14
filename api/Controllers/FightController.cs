using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class FightController : Controller
    {

        private readonly IFightRepository _repository;
        public FightController(IFightRepository repository){
            _repository = repository;
        }

        [HttpGet]
        [Route("get/{ring}")]
        public async Task<IActionResult> GetFightsToRing([FromRoute] string ring){
            var fights = await _repository.Find(f => f.Ring == ring);

            if(fights == null || fights.Count == 0)
                return BadRequest("No fights found");

            return Ok(fights);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetFight([FromRoute] int id){
            var fight = await _repository.Get(id);

            if(fight == null)
                return BadRequest("No fight found");

            return Ok(fight);

        }
        public async Task<IActionResult> GetFightDiagram()
        {
            List<Fight> fights = new List<Fight>
            {
                new Fight
                {
                    Id = 1,
                    BlueAthlete = new ApplicationUser
                    {
                        Id ="123Blue",
                        FirstName = "Tommy Gun",
                        Surname = "Wales",
                        
                    },
                    BlueAthleteId = "123Blue",
                    RedAthlete = new ApplicationUser
                    {
                        Id ="123Red",
                        FirstName = "Rocky",
                        Surname = "Balboa",

                    },
                    RedAthleteId = "123Red",
                    NextFightId = 6,
                    FightPoints = new List<FightPoint>
                    {
                        new FightPoint
                        {
                            FighterId = "123Blue",
                            Id = 1,
                            Points = 2
                        },
                        new FightPoint
                        {
                            FighterId = "123Blue",
                            Id = 2,
                            Points = 4
                        },
                        new FightPoint
                        {
                            FighterId = "123Red",
                            Id = 3,
                            Points = 2
                        }
                    }
                },
                new Fight
                {
                    Id = 2,
                    BlueAthlete = new ApplicationUser
                    {
                        Id ="12345Blue",
                        FirstName = "Chuck",
                        Surname = "Norris",

                    },
                    BlueAthleteId = "12345Blue",
                    RedAthlete = new ApplicationUser
                    {
                        Id ="12345Red",
                        FirstName = "Bruce",
                        Surname = "Lee",

                    },
                    RedAthleteId = "12453Red",
                    NextFightId = 6
                },
                 new Fight
                {
                    Id = 3,
                    BlueAthlete = new ApplicationUser
                    {
                        Id ="12345Blue",
                        FirstName = "Chuck",
                        Surname = "Norris",

                    },
                    BlueAthleteId = "12345Blue",
                    RedAthlete = new ApplicationUser
                    {
                        Id ="12345Red",
                        FirstName = "Bruce",
                        Surname = "Lee",

                    },
                    RedAthleteId = "12453Red",
                    NextFightId = 7
                }, new Fight
                {
                    Id = 4,
                    BlueAthlete = new ApplicationUser
                    {
                        Id ="12345Blue",
                        FirstName = "Chuck",
                        Surname = "Norris",

                    },
                    BlueAthleteId = "12345Blue",
                    RedAthlete = new ApplicationUser
                    {
                        Id ="12345Red",
                        FirstName = "Bruce",
                        Surname = "Lee",

                    },
                    RedAthleteId = "12453Red",
                    NextFightId = 7
                },

                new Fight
                {
                    Id = 6,
                     NextFightId = 8
                },
                new Fight
                {
                    Id = 7,
                     NextFightId = 8
                },
                new Fight
                {
                    Id = 8
                },

            };

           // var fights = await _repository.GetAll();

            Fights.FighDiagramtProvider provider = new Fights.FighDiagramtProvider(fights);

            var gameList = provider.GenerateFightDiagram();

            var games = Newtonsoft.Json.JsonConvert.SerializeObject(gameList.ToArray(), new Newtonsoft.Json.JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            return Ok(games);
        }

        
    }
}