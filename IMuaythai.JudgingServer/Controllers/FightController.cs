using System.Linq;
using System.Threading.Tasks;
using IMuaythai.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.JudgingServer.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class FightController : Controller
    {

        private readonly IFightRepository _repository;
        public FightController(IFightRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("get/{contestId}/{ringId}")]
        public async Task<IActionResult> GetFightsToRing([FromRoute] int contestId, string ringId)
        {
            var fights = await _repository.Find(f => f.Ring == ringId
            && f.ContestId == contestId
            && !string.IsNullOrEmpty(f.BlueAthleteId)
            && !string.IsNullOrEmpty(f.RedAthleteId)
            && string.IsNullOrEmpty(f.WinnerId));

            if (fights == null || fights.Count == 0)
                return BadRequest("No fights found");

            var fightsDto = fights.Select(f => new
            {
                f.Id,
                f.StartNumber,
                BlueAthlete = new
                {
                    f.BlueAthlete.Id,
                    f.BlueAthlete.FirstName,
                    f.BlueAthlete.Surname
                },
                RedAthlete = new
                {
                    f.RedAthlete.Id,
                    f.RedAthlete.FirstName,
                    f.RedAthlete.Surname
                },
            }).ToList();

            return Ok(fightsDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetFight([FromRoute] int id)
        {
            var fight = await _repository.Get(id);

            if (fight == null)
                return BadRequest("No fight found");

            var fightDto = new
            {
                fight.Id,
                BlueAthlete = new
                {
                    fight.BlueAthlete.Id,
                    fight.BlueAthlete.FirstName,
                    fight.BlueAthlete.Surname
                },
                RedAthlete = new
                {
                    fight.RedAthlete.Id,
                    fight.RedAthlete.FirstName,
                    fight.RedAthlete.Surname
                },
                FightJudgesMappings = fight.FightJudgesMappings.Select(f => new
                {
                    f.Id,
                    f.Main,
                    Judge = new
                    {
                        f.Judge.Id,
                        f.Judge.FirstName,
                        f.Judge.Surname
                    }
                }).ToList(),
                Structure = new
                {
                    fight.Structure.Round,
                    fight.Structure.WeightAgeCategory
                },
                Referee = new
                {
                    fight.Referee.Id,
                    fight.RedAthlete.FirstName,
                    fight.Referee.Surname
                },
                Timekeeper = new
                {
                    fight.TimeKeeper.Id,
                    fight.TimeKeeper.FirstName,
                    fight.TimeKeeper.Surname
                }
            };
            
            return Ok(fightDto);

        }
    }
}