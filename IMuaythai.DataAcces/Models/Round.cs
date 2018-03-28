namespace IMuaythai.DataAccess.Models
{
    public class Round: Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Time in seconds
        /// </summary>
        public int Duration { get; set; }
        public int RoundsCount { get; set; }
        public int BreakDuration { get; set; }
    }

}
