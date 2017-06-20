using System;
using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class Suspension
    {
        [Key]
        public int Id { get; set; }
      
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
  
        public string Description { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual SuspensionType SuspensionType { get; set; }
    }
}