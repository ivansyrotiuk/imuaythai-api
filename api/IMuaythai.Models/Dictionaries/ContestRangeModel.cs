using IMuaythai.DataAccess.Models;

namespace IMuaythai.Models.Dictionaries
{
    public class ContestRangeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static explicit operator ContestRangeModel(ContestRange range)
        {
            return new ContestRangeModel
            {
                Id = range.Id,
                Name = range.Name
            };
        }
    }
}
