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
        public int ContestTypePointsId { get; set; }
        public int FightStructureId { get; set; }
        public int? InstitutionId { get; set; }
        public string Name { get; set; }

        public virtual ContestTypePoints ContestTypePoints { get; set; }
        public virtual FightStructure FightStructure { get; set; }
        public virtual IEnumerable<ContestRequest> ContestRequests { get; set; }
        public virtual Institution Institution { get; set; }
    }
}
