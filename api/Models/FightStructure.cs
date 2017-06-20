using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class FightStructure
    {
        [Key]
        public int Id { get; set; }
        public int WeightAgeCategoryId { get; set; }
        public int RoundlId { get; set; }

        public ContestCategory[] ContestCategories { get; set; }
        public Fight[] Fights { get; set; }
    }
}
