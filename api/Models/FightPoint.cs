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
        [Required]
        public int Id { get; set; }
        [Required]
        public int RoundId{ get; set; }
        public string  JudgeID { get; set; }
        [Required]
        public int Points { get; set; }
        [Required]
        public string Cautions { get; set; }
        [Required]
        public string Wamings { get; set; }
        [Required]
        public Byte Accepted { get; set; }
        [Required]
        public int FigthId { get; set; }
    }
}
