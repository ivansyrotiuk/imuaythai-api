using System;
using System.ComponentModel.DataAnnotations;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class Suspension
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Userid { get; set; }
        public DateTime From { get; set; }

    }
}