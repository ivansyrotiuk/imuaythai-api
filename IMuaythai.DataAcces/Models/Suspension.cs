using System;

namespace IMuaythai.DataAccess.Models
{
    public class Suspension
    {
        public int Id { get; set; }
      
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
  
        public string Description { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual SuspensionType SuspensionType { get; set; }
    }
}