using System.ComponentModel.DataAnnotations;

namespace IMuaythai.DataAccess.Models
{
    public class ContestCategoriesMapping
    {
        [Key]
        public int Id { get; set; }
        public int ContestId { get; set; }
        public int ContestCategoryId { get; set; }
        public virtual Contest Contest { get; set; }
        public virtual ContestCategory ContestCategory { get; set; }
    }
}
