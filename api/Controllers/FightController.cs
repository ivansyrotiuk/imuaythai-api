using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Fights;
using MuaythaiSportManagementSystemApi.Data;
using Microsoft.EntityFrameworkCore;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    public class FightController : Controller
    {
        private readonly IFightsTreePersister _fightsTreePersister;
        private readonly ApplicationDbContext _context;
        public FightController(IFightsTreePersister fightsTreePersister, ApplicationDbContext context)
        {
            _fightsTreePersister = fightsTreePersister;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var fighters = _context.Users.ToList();
            _context.Fights.RemoveRange(_context.Fights.Where(f => f.ContestId == 11));
            FightsTree tree = new FightsTree(11, 1, 16);
            tree.Print();

            await _fightsTreePersister.Save(tree);

            var fights = _context.Fights.Where(f => f.ContestId == 11).ToList();
    
            FightersTossupper tossupper = new FightersTossupper();
            tossupper.Tossup(fighters, tree);
  
            FightsDiagramBuilder provider = new FightsDiagramBuilder(fights);

            var gameList = provider.GenerateFightDiagram();

            var games = Newtonsoft.Json.JsonConvert.SerializeObject(gameList.ToArray(), new Newtonsoft.Json.JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });



            return Ok(games);
        }



        //[HttpGet]
        //public async Task<IActionResult> Index([FromQuery] int count)
        //{
        //    if (count == 0)
        //    {
        //        count = 16;
        //    }

        //    List<Fight> fights = new List<Fight>
        //    {
        //          new Fight
        //        {
        //            Id = 100,
        //            BlueAthlete = new ApplicationUser
        //            {
        //                Id ="123Blue",
        //                FirstName = "Tommy Gun",
        //                Surname = "Wales",

        //            },
        //            BlueAthleteId = "123Blue",
        //            RedAthlete = new ApplicationUser
        //            {
        //                Id ="123Red",
        //                FirstName = "Rocky",
        //                Surname = "Balboa",

        //            },
        //            RedAthleteId = "123Red",
        //            NextFightId = 1,
        //            FightPoints = new List<FightPoint>
        //            {
        //                new FightPoint
        //                {
        //                    FighterId = "123Blue",
        //                    Id = 1,
        //                    Points = 2
        //                },
        //                new FightPoint
        //                {
        //                    FighterId = "123Blue",
        //                    Id = 2,
        //                    Points = 4
        //                },
        //                new FightPoint
        //                {
        //                    FighterId = "123Red",
        //                    Id = 3,
        //                    Points = 2
        //                }
        //            }
        //        },
        //        new Fight
        //        {
        //            Id = 0,
        //            BlueAthlete = new ApplicationUser
        //            {
        //                Id ="123Blue",
        //                FirstName = "Tommy Gun",
        //                Surname = "Wales",

        //            },
        //            BlueAthleteId = "123Blue",
        //            RedAthlete = new ApplicationUser
        //            {
        //                Id ="123Red",
        //                FirstName = "Rocky",
        //                Surname = "Balboa",

        //            },
        //            RedAthleteId = "123Red",
        //            NextFightId = 1,
        //            FightPoints = new List<FightPoint>
        //            {
        //                new FightPoint
        //                {
        //                    FighterId = "123Blue",
        //                    Id = 1,
        //                    Points = 2
        //                },
        //                new FightPoint
        //                {
        //                    FighterId = "123Blue",
        //                    Id = 2,
        //                    Points = 4
        //                },
        //                new FightPoint
        //                {
        //                    FighterId = "123Red",
        //                    Id = 3,
        //                    Points = 2
        //                }
        //            }
        //        },
        //        new Fight
        //        {
        //            Id = 1,
        //            BlueAthlete = new ApplicationUser
        //            {
        //                Id ="123Blue",
        //                FirstName = "Tommy Gun",
        //                Surname = "Wales",
                        
        //            },
        //            BlueAthleteId = "123Blue",
        //            RedAthlete = new ApplicationUser
        //            {
        //                Id ="123Red",
        //                FirstName = "Rocky",
        //                Surname = "Balboa",

        //            },
        //            RedAthleteId = "123Red",
        //            NextFightId = 6,
        //            FightPoints = new List<FightPoint>
        //            {
        //                new FightPoint
        //                {
        //                    FighterId = "123Blue",
        //                    Id = 1,
        //                    Points = 2
        //                },
        //                new FightPoint
        //                {
        //                    FighterId = "123Blue",
        //                    Id = 2,
        //                    Points = 4
        //                },
        //                new FightPoint
        //                {
        //                    FighterId = "123Red",
        //                    Id = 3,
        //                    Points = 2
        //                }
        //            }
        //        },
        //        new Fight
        //        {
        //            Id = 2,
        //            BlueAthlete = new ApplicationUser
        //            {
        //                Id ="12345Blue",
        //                FirstName = "Chuck",
        //                Surname = "Norris",

        //            },
        //            BlueAthleteId = "12345Blue",
        //            RedAthlete = new ApplicationUser
        //            {
        //                Id ="12345Red",
        //                FirstName = "Bruce",
        //                Surname = "Lee",

        //            },
        //            RedAthleteId = "12453Red",
        //            NextFightId = 6
        //        },
        //         new Fight
        //        {
        //            Id = 3,
        //            BlueAthlete = new ApplicationUser
        //            {
        //                Id ="12345Blue",
        //                FirstName = "Chuck",
        //                Surname = "Norris",

        //            },
        //            BlueAthleteId = "12345Blue",
        //            RedAthlete = new ApplicationUser
        //            {
        //                Id ="12345Red",
        //                FirstName = "Bruce",
        //                Surname = "Lee",

        //            },
        //            RedAthleteId = "12453Red",
        //            NextFightId = 7
        //        },
        //        new Fight
        //        {
        //            Id = 4,
        //            BlueAthlete = new ApplicationUser
        //            {
        //                Id ="12345Blue",
        //                FirstName = "Chuck",
        //                Surname = "Norris",

        //            },
        //            BlueAthleteId = "12345Blue",
        //            RedAthlete = new ApplicationUser
        //            {
        //                Id ="12345Red",
        //                FirstName = "Bruce",
        //                Surname = "Lee",

        //            },
        //            RedAthleteId = "12453Red",
        //            NextFightId = 7
        //        },

        //        new Fight
        //        {
        //            Id = 6,
        //             NextFightId = 8
        //        },
        //        new Fight
        //        {
        //            Id = 7,
        //             NextFightId = 8
        //        },
        //        new Fight
        //        {
        //            Id = 8
        //        },

        //    };

        //    _context.Fights.RemoveRange(_context.Fights.Where(f => f.ContestId == 11));
        //    FightsTree tree = new FightsTree(11, 1, count);
        //    tree.Print();

        //    await _fightsTreePersister.Save(tree);

        //    fights = _context.Fights.Where(f => f.ContestId == 11).ToList();
        //    Fights.FightsDiagramBuilder provider = new Fights.FightsDiagramBuilder(fights);

        //    var gameList = provider.GenerateFightDiagram();

        //    var games = Newtonsoft.Json.JsonConvert.SerializeObject(gameList.ToArray(), new Newtonsoft.Json.JsonSerializerSettings
        //    {
        //        ContractResolver = new CamelCasePropertyNamesContractResolver()
        //    });

         

        //    return Ok(games);
        //}
    }
}