using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMuaythai.DataAccess.Models
{
    public class KhanLevel: Entity
    {
        [Key]
        public int Id { get; set; }
        public int Level { get; set; }
        [StringLength(500)]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
    
}