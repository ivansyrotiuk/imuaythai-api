using System;
using System.ComponentModel.DataAnnotations;

namespace IMuaythai.DataAccess.Models
{
    public class Reminder
    {
        [Key]
        public int Id { get; set; }

        public int Type { get; set; }
        [StringLength(500)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime SendDate { get; set; }

        public bool Confirmed { get; set; }

        public string UserId { get; set; }


        public virtual ApplicationUser User { get; set; }
    }
}
