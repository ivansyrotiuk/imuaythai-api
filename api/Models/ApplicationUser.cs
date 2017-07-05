using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MuaythaiSportManagementSystemApi.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [StringLength(500)]
        public string FirstName { get; set; }
        [StringLength(500)]
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        [StringLength(500)]
        public string Nationality { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(1000)]
        public string Photo { get; set; }
        [StringLength(60)]
        public string Phone { get; set; }
        public int Type { get; set; }
        public int? CountryId { get; set; }
        public int? InstitutionsId { get; set; }
        public int? KhanLevelId { get; set; }
        [StringLength(500)]
        public string Facebook { get; set; }
        [StringLength(500)]
        public string Instagram { get; set; }
        [StringLength(500)]
        public string Twitter { get; set; }
        [StringLength(500)]
        public string VK { get; set; }
        [StringLength(100)]
        public string CoachLevel { get; set; }
        [StringLength(10)]
        public int? KhanLevelsId { get; set; }

        public bool Accepted { get; set; }


        public virtual ICollection<Suspension> Suspensions { get; set; }
        public virtual ICollection<UserDocumentsMapping> UserDocimentsMappings { get; set; }
        public virtual ICollection<ExecutionBoard> ExecutionBoards { get; set; }
        public virtual ICollection<ContestRequest> ContestRequests { get; set; }
        public virtual ICollection<ContestRequest> AcceptedContestRequests { get; set; }
        public virtual ICollection<Fight> AsRedFights { get; set; }
        public virtual ICollection<Fight> AsBlueFights { get; set; }
        public virtual ICollection<Fight> AsTimeKeeperFights { get; set; }
        public virtual ICollection<Fight> AsRefereeFights { get; set; }
        public virtual ICollection<Fight> WonFights { get; set; }
        public virtual ICollection<FightJudgesMapping> FightJudgesMappings { get; set; }
        public virtual ICollection<FightPoint> FightPoints { get; set; }
        public virtual Institution Institution { get; set; }
        public virtual Country Country { get; set; }
        public virtual KhanLevel KhanLevel { get; set; }

    }
}
