using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class UserDocimentsMapping
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string UserId { get; set; }
        public int DocumentId  { get; set; }
    }
}
