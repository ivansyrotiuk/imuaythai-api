using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Models
{
    //Turnament, Cup, Championship
    public class ContestType
    {
        [Key]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }

        public virtual ICollection<Contest> Contests { get; set; }
    }
}
