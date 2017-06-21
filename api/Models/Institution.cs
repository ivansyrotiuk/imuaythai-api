using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class Institution
    {
        [Key]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Logo { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string City { get; set; }
        public int Countryid { get; set; }
        [StringLength(500)]
        public string ContactPerson { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }
        [StringLength(500)]
        public string Email { get; set; }
        [StringLength(100)]
        public string HeadCoachid { get; set; }
        [StringLength(500)]
        public string Owner { get; set; }
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
        public int MembersCount { get; set; }

        public virtual ICollection<InstitutionDocumentsMapping> InstitutionDocumentsMappings { get; set; }
        public virtual ICollection<ContestRequest> ContestRequests { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<ExecutionBoard> ExecutionBoards { get; set; }
        public virtual ICollection<Contest> Contests { get; set; }
        public virtual Country Country { get; set; }
    }
}