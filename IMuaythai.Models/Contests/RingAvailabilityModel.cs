using System;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Models.Contests
{
    public class RingAvailabilityModel
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Name { get; set; }

        public RingAvailabilityModel()
        {

        }

        public RingAvailabilityModel(ContestRing ring )
        {
            Id = ring.Id;
            From = ring.From;
            To = ring.To;
            Name = ring.Name;
        }

        public static explicit operator RingAvailabilityModel(ContestRing ring)
        {
            return new RingAvailabilityModel(ring);
        }
    }
}