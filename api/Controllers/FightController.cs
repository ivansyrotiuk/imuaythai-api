using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    public class FightController : Controller
    {
        public IActionResult Index()
        {
            Fights.FightProvider provider = new Fights.FightProvider();

            var home = provider.GenerateGame();
            var visitor = provider.GenerateGame();
            var complex = provider.GenerateComplexGame(home, visitor);

            var gameArray = new[] { complex ,home, visitor,  };

            var games = Newtonsoft.Json.JsonConvert.SerializeObject(gameArray, new Newtonsoft.Json.JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            return Ok(games);
        }
    }
}