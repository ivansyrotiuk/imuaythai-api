using MuaythaiSportManagementSystemApi.Extensions;
using MuaythaiSportManagementSystemApi.Fights.FightsStructure;
using MuaythaiSportManagementSystemApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Fights
{
    public class FightsDiagramBuilder : IFightsDiagramBuilder
    {

        private List<Fight> _fights;
        private List<Game> _games;
        private string _rootFightId;

        public List<Game> GenerateFightDiagram(List<Fight> fights)
        {
            _fights = fights;
            _games = new List<Game>();

            var rootFight = _fights.FirstOrDefault(f => f.NextFightId == null);

            if (rootFight == null)
                return new List<Game>();
            _rootFightId = rootFight.Id.ToString();
            BuildFightDiagram(rootFight);

            return _games;
        }

        public string ToJson()
        {
            string gamesJson = Newtonsoft.Json.JsonConvert.SerializeObject(_games.ToArray(), new Newtonsoft.Json.JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            return gamesJson;
        }

        private void BuildFightDiagram(Fight root)
        {
            var figthsToRoot = _fights.Where(f => f.NextFightId == root.Id).ToList();
   
            foreach (var fight in figthsToRoot)
            {
                BuildFightDiagram(fight);
            }

            var parsedFight = ParseToFightBracket(root);

            if (figthsToRoot.Count != 0)
            {
                foreach (var subFight in figthsToRoot)
                {
                    var game = _games.FirstOrDefault(g => g.Id == subFight.Id.ToString());

                    AddDepedencyBetweenFights(game, parsedFight);
                }
            }
            else
            {
                parsedFight.HomeSeed.Rank = 2;
                parsedFight.VisitorSeed.Rank = 2;

            }

            if(_rootFightId == parsedFight.Id)
            {
                parsedFight.Name = "Mistrzostwa Świata Muaythai IFMA w Mińsku";
            }

            _games.Add(parsedFight);


        }

        private void AddDepedencyBetweenFights(Game game, Game parsedFight)
        {
            if(parsedFight.HomeSeed.SourceGame == null)
            {
                parsedFight.HomeSeed.SourceGame = game;
                parsedFight.HomeSeed.Rank = 1;
                var team = GetTeam(game);
                parsedFight.HomeTeam = team;
                parsedFight.Sides.Home.Team = team;

            }
            else
            {
                parsedFight.VisitorSeed.SourceGame = game;
                parsedFight.VisitorSeed.Rank = 1;
                var team = GetTeam(game);
                parsedFight.VisitorTeam = team;
                parsedFight.Sides.Visitor.Team = team;
                
            }
        }

        private Team GetTeam(Game game)
        {
            if(game.HomeScore != null && game.VisitorScore != null && game.VisitorScore.Score > 0 && game.HomeScore.Score > 0)
            {
                return game.VisitorScore.Score > game.HomeScore.Score ? game.VisitorTeam : game.HomeTeam;
            }

            return null;
        }

        private Game ParseToFightBracket(Fight fight)
        {
            var homeTeam = fight.RedAthlete != null ? BuildTeam(fight.RedAthlete) : null;
            var homeSeed = BuildSeed(fight);
            var homeScore = fight.FightPoints != null ? BuildScore(fight.FightPoints, fight.RedAthleteId) : null;

            var visitorTeam = fight.BlueAthlete != null ? BuildTeam(fight.BlueAthlete) : null;
            var visitorSeed = BuildSeed(fight);
            var visitorScore = fight.FightPoints != null ? BuildScore(fight.FightPoints, fight.BlueAthleteId) : null;

            return new Game
            {
                Created = DateTime.Now.ToUnixDateTime(),
                EventType = "Game",
                ExternalId = fight.Id.ToString(),
                //GameGroup = group,
                HomeScore = homeScore,
                HomeSeed = homeSeed ,
                HomeTeam = homeTeam,
                Id = fight.Id.ToString(),
                IgnoreStandings = false,
                LocalDate = DateTime.Now.ToString("dd-MM-yyyy"),
                Scheduled = DateTime.Now.ToUnixDateTime(),
                Sides = new Sides
                {
                    Home = new Side
                    {
                        Score = homeScore,
                        Seed = homeSeed,
                        Team = homeTeam
                    },
                    Visitor = new Side
                    {
                        Score = visitorScore,
                        Seed = visitorSeed,
                        Team = visitorTeam
                    }
                },
                Version = 1,
                Updated = DateTime.Now.ToUnixDateTime(),
                VisitorScore = visitorScore,
                VisitorSeed = visitorSeed,
                VisitorTeam = visitorTeam,
                //Court = court
            };
        }

        private Team BuildTeam(ApplicationUser redAthlete)
        {
            return new Team
            {
                Id = redAthlete.Id,
                ExternalId = redAthlete.Id,
                Name = $"{redAthlete.FirstName} {redAthlete.Surname}",
                //NumGames = redAthlete.WonFights.Count()
            };
        }

        private Seed BuildSeed(Fight fight)
        {
            return new Seed
            {
                DisplayName = "Fighter",
                Rank = 2
            };
        }

        private ScoreNode BuildScore(ICollection<FightPoint> fightPoints, string fighterId)
        {
            return new ScoreNode
            {
                Score = fightPoints.Where(f => f.FighterId == fighterId).Sum(f => f.Points)
            };
        }
    }
}
