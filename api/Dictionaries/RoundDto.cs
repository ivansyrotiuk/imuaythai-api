using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Dictionaries
{
    public class RoundDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int RoundsCount { get; set; }
        public int BreakDuration { get; set; }

        public static explicit operator RoundDto(Round round)
        {
            return new RoundDto
            {
                Id = round.Id,
                Name = round.Name,
                Duration = round.Duration,
                RoundsCount = round.RoundsCount,
                BreakDuration = round.BreakDuration
            };
        }
    }
}
