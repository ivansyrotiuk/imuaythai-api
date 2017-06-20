using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class ContestCategorie
    {
        [Key]
        public int Id { get; set;}
        public int ContestsId { get; set; }
        public int FightStructure { get; set; }

    }
}
