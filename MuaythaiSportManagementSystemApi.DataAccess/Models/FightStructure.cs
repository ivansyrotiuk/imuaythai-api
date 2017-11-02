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
        public int RoundId { get; set; }

        public ICollection<ContestCategory> ContestCategories { get; set; }
        public ICollection<Fight> Fights { get; set; }
        public virtual WeightAgeCategory WeightAgeCategory { get; set; }
        public virtual Round Round { get; set; }
    }

}
