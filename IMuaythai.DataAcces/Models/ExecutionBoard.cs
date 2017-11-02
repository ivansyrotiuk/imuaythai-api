namespace IMuaythai.DataAccess.Models
{
    public class ExecutionBoard
    {
        public int Id { get; set; }
        public int ExecutionPosition { get; set; }
     
        public ApplicationUser User { get; set; }
        public Institution Institution { get; set; }
    }
}
