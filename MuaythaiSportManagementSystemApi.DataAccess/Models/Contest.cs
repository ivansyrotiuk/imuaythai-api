using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class Contest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime EndRegistrationDate { get; set; }
        public int Duration { get; set; }
        public int RingsCount { get; set;}
        public int InstitutionId { get; set; }
        public int CountryId { get; set; }
        public int? ContestRangeId { get; set; }
        public int? ContestTypeId { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
        [Required]
        [StringLength(500)]
        public string City { get; set; }
        [StringLength(500)]
        public string Website { get; set; }
        [StringLength(500)]
        public string Facebook { get; set; }
        [StringLength(500)]
        public string Instagram { get; set; }
        [StringLength(500)]
        public string VK { get; set; }
        [StringLength(500)]
        public string Twitter { get; set; }

        public int WaiKhruTime { get; set; }

        public bool AllowUnassociated { get; set; }

        public virtual ICollection<Fight> Fights { get; set; }
        public virtual ICollection<ContestCategoriesMapping> ContestCategoriesMappings { get; set; }
        public virtual ICollection<ContestRequest> ContestRequests { get; set; }
        public virtual ICollection<ContestDocumentsMapping> ContestDocumentsMappings { get; set; }
        public virtual ICollection<ContestRing> Rings { get; set; }
        public virtual Institution Institution { get; set; }
        public virtual Country Country { get; set; }
        public virtual ContestRange ContestRange { get; set; }
        public virtual ContestType ContestType { get; set; }

    }
}