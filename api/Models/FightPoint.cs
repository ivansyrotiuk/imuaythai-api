using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class FightPoint
    {
        [Key]
    
        public int Id { get; set; }

        public int RoundId{ get; set; }

        public string FighterId { get; set; }

        public int Points { get; set; }
  
        public string Cautions { get; set; }
      
        public string Warnings { get; set; }
      
        public bool Accepted { get; set; }

        public virtual Fight Fight { get; set; }
        public virtual ApplicationUser Judge { get; set; }
        public virtual ApplicationUser Fighter { get; set; }
    }
}
