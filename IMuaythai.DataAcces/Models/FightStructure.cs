using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMuaythai.DataAccess.Models
{
    public class FightStructure: Entity
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
