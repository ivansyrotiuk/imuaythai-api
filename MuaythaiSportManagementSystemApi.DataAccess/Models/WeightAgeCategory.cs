using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class WeightAgeCategory
    {
        [Key]
        public int Id {get;set;}
        public string Name { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public decimal MinWeight { get; set; }
        public decimal MaxWeight { get; set; }
        public string Gender { get; set; }

    }
}
