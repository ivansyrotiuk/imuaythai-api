using MuaythaiSportManagementSystemApi.Fights.FightsStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Fights
{
    public class FightProvider
    {
        public Game GenerateGame()
        {
            Division division = new Division
            {
                Id = Guid.NewGuid().ToString().Substring(0, 10),
                Version = 0,
                Created = 1465591789000,
                Updated = 1465591789000,
                Name = "GameGroup test",
                ExternalId = "GameGrouptest",
                Tourney = new Tourney
                {

                }
            };
            GameGroup pool = new GameGroup
            {
                Id = Guid.NewGuid().ToString().Substring(0, 10),
                Version = 0,
                Created = 1465591789000,
                Updated = 1465591789000,
                Name = "HomeA",
                ExternalId = "HomeA",
                Type = "Pool",
                Division = division
            };

            GameGroup poolVisitor = new GameGroup
            {
                Id = Guid.NewGuid().ToString().Substring(0, 10),
                Version = 0,
                Created = 1465591789000,
                Updated = 1465591789000,
                Name = "VisitorB",
                ExternalId = "VisitorB",
                Type = "Pool",
                Division = division
            };

            ScoreNode homeScore = new ScoreNode
            {
                Score = 10
            };

            Seed homeSeed = new Seed
            {
               DisplayName = "Winner of something",
               Rank  = 2,
               SourcePool = pool
            };

            Team homeTeam = new Team
            {
                Id = Guid.NewGuid().ToString().Substring(0, 10),
                Version = 0,
                Created = 1465591789000,
                Updated = 1465591789000,
                Pool = pool,
                Name = "Tommy Gun Wales",
                ExternalId = "FightTommyGunWales",
                NumGames = 3
            };

            ScoreNode visitorScore = new ScoreNode
            {
                Score = 5
            };

            Seed visitorSeed = new Seed
            {
                DisplayName = "Winner of sub something",
                Rank = 2,
                SourcePool = poolVisitor

            };

            Team visitorTeam = new Team
            {
                Id = Guid.NewGuid().ToString().Substring(0, 10),
                Version = 0,
                Created = 1465591789000,
                Updated = 1465591789000,
                Pool = poolVisitor,
                Name = "Chuck Norris",
                ExternalId = "FightTommyGunWales",
                NumGames = 3
            };

            return new Game
            {
                Created = 1465591789000,
                EventType = "Game",
                ExternalId = Guid.NewGuid().ToString().Substring(0, 10),
                GameGroup = new GameGroup
                {
                    Id = Guid.NewGuid().ToString().Substring(0, 10),
                    Version = 2,
                    Created = 1465591789000,
                    Updated = 1465591789000,
                    Division = division,
                    Name = "Test test",
                    ExternalId = "Testtest",
                    Type = "Bracket"

                },
                HomeScore = homeScore,
                HomeSeed = homeSeed,
                HomeTeam = homeTeam,
                Id = Guid.NewGuid().ToString().Substring(0, 10),
                IgnoreStandings = false,
                LocalDate = DateTime.Now.ToString("dd-MM-yyyy"),
                Name = "Semi finals",
                Scheduled = 1465591789000,
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
                Updated = 1465591789000,
                VisitorScore = visitorScore,
                VisitorSeed = visitorSeed,
                VisitorTeam = visitorTeam


            };
        }
    }
}
