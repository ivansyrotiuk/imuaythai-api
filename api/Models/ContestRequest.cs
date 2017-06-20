using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class ContestRequest
    {
        public int Id { get; set; }
        public bool Accepted { get; set; }
        public int Type { get; set; }
        public DateTime Date { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Institution Institution { get; set; }
        public virtual Contest Contest { get; set; }
        public virtual ApplicationUser AcceptedBy { get; set; }
        public ContestCategory ContestCategory { get; set; }
    }
}
