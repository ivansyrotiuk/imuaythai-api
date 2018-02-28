using System;
using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using IMuaythai.JudgingServer.State;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace IMuaythai.UnitTests
{
    public class FightStateTests
    {
        [Fact]
        public void Initialize_PassedFightId_ShouldReturnFreshState()
        {
            var fightEntity = new Fight
            {
                Id = 1,
                BlueAthleteId = "abcd",
                RedAthleteId = "efgh"
            };
            var context = GetDefaultDatabaseContext();
            var fightState = new FightState(context);
            context.Fights.Add(fightEntity);
            context.SaveChanges();

            fightState.Initialize(1);
            var expected = new FightState(context)
            {
                BlueFighter = new Fighter("abcd", new List<FightPoint>()),
                RedFighter = new Fighter("efgh", new List<FightPoint>()),
                Round = 0,
                Id = 1
            };
            
            Assert.Equal(expected, fightState);
        }
        [Fact]
        public void Initialize_PassedFightId_ShouldReturnPersistedState()
        {
            var fightEntity = new Fight
            {
                Id = 1,
                BlueAthleteId = "abcd",
                RedAthleteId = "efgh"
            };
            var fightPoints = new List<FightPoint>
            {
                new FightPoint
                {
                    FightId = 1,
                    JudgeId = "qwerty",
                    Points = 9,
                    FighterId = "abcd",
                    RoundId = 1
                },
                new FightPoint
                {
                    FightId = 1,
                    JudgeId = "qwerty",
                    Points = 10,
                    FighterId = "efgh",
                    RoundId = 1
                }
            };
            var context = GetDefaultDatabaseContext();
            var fightState = new FightState(context);
            context.Fights.Add(fightEntity);
            context.FightPoints.AddRange(fightPoints);
            context.SaveChanges();

            fightState.Initialize(1);
            var expected = new FightState(context)
            {
                BlueFighter = new Fighter("abcd", fightPoints.Where(f => f.FighterId == "abcd").ToList()),
                RedFighter = new Fighter("efgh", fightPoints.Where(f => f.FighterId == "efgh").ToList())
            };
            Assert.Equal(expected, fightState);
        }

        private ApplicationDbContext GetDefaultDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            
            var contextMock = new ApplicationDbContext(options);
            return contextMock;
        }

        
    }
}