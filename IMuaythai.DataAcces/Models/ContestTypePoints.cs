using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMuaythai.DataAccess.Models
{
    public class ContestTypePoints
    {
        [Key]
        public int Id { get; set; }
        public decimal Points { get; set; }
        public int ContestTypeId  { get; set; }
        public int ContestRangeId { get; set; }
        public int? InstitutionId { get; set; }

        public virtual ContestType ContestType { get; set; }
        public virtual ContestRange ContestRange { get; set; }
        public virtual Institution Institution { get; set; }


        public virtual ICollection<ContestCategory> Categories { get; set; }
    }
}
