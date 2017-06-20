using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MuaythaiSportManagementSystemApi.Models
{
    public class User
    {
        [Key]
        [Required]
        [StringLength(100)]
        public string Id { get; set; }
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
        [StringLength(500)]
        public string Email { get; set; }
        [StringLength(60)]
        public string Phone { get; set; }
        public int Type { get; set; }
        public int CountryId { get; set; }
        public int InstitutionsId { get; set; }
        public int KhanLevelId { get; set; }
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
        public int KhanLevelsId { get; set; }




    }
}
