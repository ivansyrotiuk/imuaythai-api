using System;
using System.Collections.Generic;

namespace IMuaythai.Models.Contests
{
    public class ContestRingModel
    {
        public DateTime ContestDay { get; set; }
        public int RingsCount { get; set; }
        public int ContestId { get; set; }
        public List<RingAvailabilityModel> RingsAvilability { get; set; }
    }
}
