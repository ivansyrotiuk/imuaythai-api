namespace MuaythaiSportManagementSystemApi.Models
{
    public class Round
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Time in seconds
        /// </summary>
        public int Duration { get; set; }
        public int RoundsCount { get; set; }
    }

}
