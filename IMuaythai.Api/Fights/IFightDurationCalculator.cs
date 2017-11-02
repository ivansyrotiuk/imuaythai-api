using System;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Api.Fights
{
    public interface IFightDurationCalculator
    {
        TimeSpan CalculateFightDuration(Round round);
    }

    public class FightDurationCalculator : IFightDurationCalculator
    {
        public TimeSpan CalculateFightDuration(Round round)
        {
            var fightDuration = round.BreakDuration * (round.RoundsCount - 1) +
                                round.Duration * round.RoundsCount;

            return  new TimeSpan(0, fightDuration, 0);
        }
    }
}