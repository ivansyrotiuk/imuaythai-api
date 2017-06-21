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
        public int Duration { get; set; }
        public int RingsCount { get; set;}
        public int Institutionld { get; set; }
        public int CountryId { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
        [Required]
        [StringLength(500)]
        public string City { get; set; }

        public virtual ICollection<Fight> Fights { get; set; }
        public virtual ICollection<ContestCategory> ContestCategories { get; set; }
        public virtual ICollection<ContestRequest> ContestRequests { get; set; }

        public virtual Institution Institution { get; set; }
        public virtual Country Country { get; set; }

    }
}