using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMuaythai.DataAccess.Models
{
    public class ContestCategory: Entity
    {
        [Key]
        public int Id { get; set;}
        public int ContestTypePointsId { get; set; }
        public int FightStructureId { get; set; }
        public int? InstitutionId { get; set; }
        public int ServiceBreakDuration { get; set; }
        public string Name { get; set; }

        public virtual ContestTypePoints ContestTypePoints { get; set; }
        public virtual FightStructure FightStructure { get; set; }
        public virtual IEnumerable<ContestRequest> ContestRequests { get; set; }
        public virtual Institution Institution { get; set; }
    }
}
