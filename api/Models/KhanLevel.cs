using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class KhanLevel
    {
        [Key]
        public int Id { get; set; }
        public int Level { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
    }
    
}