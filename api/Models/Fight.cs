using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MuaythaiSportManagementSystemApi.Models
{
    public class Fight
    {
        [Key]
        public int Id { get; set; }
        public int ContestId { get; set; }
        public int StructureId { get; set; }
        [StringLength(100)]
        public string RedAthleteId { get; set; }
        [StringLength(100)]
        public string BlueAthleteId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [StringLength(100)]
        public string TimeKeeperId { get; set; }
        [StringLength(100)]
        public string RefereeId { get; set; }
        [StringLength(100)]
        public string Winner { get; set; }
        [Required]
        public byte KO { get; set;}
        [Required]
        [StringLength(100)]
        public string Ring { get; set; }
        [Required]
        public DateTime KOTime { get; set; }
    }
}
