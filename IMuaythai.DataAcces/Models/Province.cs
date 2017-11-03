using System.ComponentModel.DataAnnotations;

namespace IMuaythai.DataAccess.Models
{
    public class Province
    {
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        [StringLength(100)]
        public string ProvinceName { get; set; }

        public virtual Country Country { get; set; }
    }
}
