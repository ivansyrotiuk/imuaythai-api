using IMuaythai.DataAccess.Models;

namespace IMuaythai.Models.Dictionaries
{
    public class RoundModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int RoundsCount { get; set; }
        public int BreakDuration { get; set; }

        public static explicit operator RoundModel(Round round)
        {
            return new RoundModel
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
