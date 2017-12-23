using System;

namespace IMuaythai.Models.Contests
{
    public class RingAvailabilityModel
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Name { get; set; }
    }
}