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
        public int? ContestCategoryId { get; set; }
        public string RedAthleteId { get; set; }
  
        public string BlueAthleteId { get; set; }
   
        public DateTime? StartDate { get; set; }

        public string TimeKeeperId { get; set; }

        public string RefereeId { get; set; }

        public byte? KO { get; set;}

        public string Ring { get; set; }
    
        public int? KOTime { get; set; }

        public int? NextFightId { get; set; }

        public virtual ICollection<FightPoint> FightPoints { get; set; }
        public virtual ICollection<FightJudgesMapping> FightJudgesMappings { get; set; }

        public virtual Fight NextFight { get; set; }
        public virtual Contest Contest { get; set; }
        public virtual ContestCategory ContestCategory { get; set; }
        public virtual FightStructure Structure { get; set; }
        public virtual ApplicationUser RedAthlete { get; set; }
        public virtual ApplicationUser BlueAthlete { get; set; }
        public virtual ApplicationUser TimeKeeper { get; set; }
        public virtual ApplicationUser Referee { get; set; }
        public virtual ApplicationUser Winner { get; set; }
    }
}
