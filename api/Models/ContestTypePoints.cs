using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class ContestTypePoints
    {
        [Key]
        public int Id { get; set; }
        public decimal Points { get; set; }
        public int TypeId { get; set; }
        public int RangeId { get; set; }

        public virtual ContestType ContestType { get; set; }
        public virtual ContestRange ContestRange { get; set; }
        public virtual Institution Institution { get; set; }
    }
}
