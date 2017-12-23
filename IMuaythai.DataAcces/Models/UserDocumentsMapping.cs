using System.ComponentModel.DataAnnotations;

namespace IMuaythai.DataAccess.Models
{
    public class UserDocumentsMapping
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

        public virtual Document Document { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
