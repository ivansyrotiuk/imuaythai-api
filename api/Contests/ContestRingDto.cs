using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Contests
{
    public class RingAvailabilityItem
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Name { get; set; }

        public RingAvailabilityItem()
        {

        }

        public RingAvailabilityItem(ContestRing ring )
        {
            Id = ring.Id;
            From = ring.From;
            To = ring.To;
            Name = ring.Name;
        }

        public static explicit operator RingAvailabilityItem(ContestRing ring)
        {
            return new RingAvailabilityItem(ring);
        }
    }

    public class ContestRingDto
    {
        public DateTime ContestDay { get; set; }
        public int RingsCount { get; set; }
        public int ContestId { get; set; }
        public List<RingAvailabilityItem> RingsAvilability { get; set; }
    }
}
