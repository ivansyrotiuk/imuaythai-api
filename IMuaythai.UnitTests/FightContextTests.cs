using System.Threading;
using IMuaythai.DataAccess.Models;
using IMuaythai.JudgingServer;
using Xunit;

namespace IMuaythai.UnitTests
{
    public class FightContextTests
    {
        [Fact]
        public void GetState_ShouldReturnState()
        {
            var context = new Mocks().GetDefaultDatabaseContext();
            
            var fightEntity = new Fight
            {
                Id = 1,
                BlueAthleteId = "abcd",
                RedAthleteId = "efgh",
                Structure = new FightStructure()
                {
                    Round = new Round()
                    {
                        BreakDuration = 1000,
                        Duration = 3000,
                        RoundsCount = 3
                    }
                }
            };
            context.Fights.Add(fightEntity);
            context.SaveChanges();

            var fightContext = new FightContext(context);
            fightContext.InitState(1);

            var state = fightContext.GetFightState();
            
            Assert.Equal(state.Id, 1);
            Assert.Equal(state.Paused, false);
            Assert.Equal(state.Started, false);
            Assert.Equal(state.RemainingTime, 3000);
            Assert.Equal(state.Round, 0);
            Assert.Equal(state.RedFighter.Id, "efgh");
            Assert.Equal(state.BlueFighter.Id, "abcd");
        }

        [Fact]
        public void StartRound_ShouldStartRound()
        {
            var context = new Mocks().GetDefaultDatabaseContext();
            
            var fightEntity = new Fight
            {
                Id = 1,
                BlueAthleteId = "abcd",
                RedAthleteId = "efgh",
                Structure = new FightStructure()
                {
                    Round = new Round()
                    {
                        BreakDuration = 1000,
                        Duration = 3000,
                        RoundsCount = 3
                    }
                }
            };
            context.Fights.Add(fightEntity);
            context.SaveChanges();

            var fightContext = new FightContext(context);
            fightContext.InitState(1);
            fightContext.StartRound();
            Thread.Sleep(1000);

            var state = fightContext.GetFightState();

            Assert.Equal(state.Id, 1);
            Assert.Equal(state.Paused, false);
            Assert.Equal(state.Started, true);
            Assert.True(state.RemainingTime > 1000);
            Assert.Equal(state.Round, 1);
            Assert.Equal(state.RedFighter.Id, "efgh");
            Assert.Equal(state.BlueFighter.Id, "abcd");
        }
        
        [Fact]
        public void EndRound_ShouldEndRound()
        {
            var context = new Mocks().GetDefaultDatabaseContext();
            
            var fightEntity = new Fight
            {
                Id = 1,
                BlueAthleteId = "abcd",
                RedAthleteId = "efgh",
                Structure = new FightStructure()
                {
                    Round = new Round()
                    {
                        BreakDuration = 1000,
                        Duration = 3000,
                        RoundsCount = 3
                    }
                }
            };
            context.Fights.Add(fightEntity);
            context.SaveChanges();

            var fightContext = new FightContext(context);
            fightContext.InitState(1);
            fightContext.EndRound();
            Thread.SpinWait(1000);

            var state = fightContext.GetFightState();
            Assert.Equal(state.Id, 1);
            Assert.Equal(state.Paused, false);
            Assert.Equal(state.Started, false);
            Assert.True(state.RemainingTime < 1000);
            Assert.Equal(state.Round, 1);
            Assert.Equal(state.RedFighter.Id, "efgh");
            Assert.Equal(state.BlueFighter.Id, "abcd");
        }
        
    }
}