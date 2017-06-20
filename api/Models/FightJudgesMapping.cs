using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class FightJudgesMapping
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int FigthId { get; set; }
        [StringLength(100)]
        public string JudgeId { get; set; }
        [Required]
        public int Main { get; set; }


    }
}
