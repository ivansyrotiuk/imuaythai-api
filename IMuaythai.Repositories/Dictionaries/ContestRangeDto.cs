using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Dictionaries
{
    public class ContestRangeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static explicit operator ContestRangeDto(ContestRange range)
        {
            return new ContestRangeDto
            {
                Id = range.Id,
                Name = range.Name
            };
        }
    }
}
