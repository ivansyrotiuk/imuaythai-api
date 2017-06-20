using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class ContestCategory
    {
        [Key]
        public int Id { get; set;}

        public virtual FightStructure FightStructure { get; set; }
        public virtual IEnumerable<ContestRequest> ContestRequests { get; set; }
        public virtual Contest Contest { get; set; }
    }
}
