using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMuaythai.DataAccess.Models
{
    public class Contest: Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime EndRegistrationDate { get; set; }
        public int Duration { get; set; }
        public int RingsCount { get; set;}
        public int InstitutionId { get; set; }
        public int CountryId { get; set; }
        public int? ContestRangeId { get; set; }
        public int? ContestTypeId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string VK { get; set; }
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