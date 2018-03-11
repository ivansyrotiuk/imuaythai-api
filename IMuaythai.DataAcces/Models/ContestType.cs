using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMuaythai.DataAccess.Models
{
    //Turnament, Cup, Championship
    public class ContestType: Entity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; } = "";

        public virtual ICollection<Contest> Contests { get; set; }
    }
}
