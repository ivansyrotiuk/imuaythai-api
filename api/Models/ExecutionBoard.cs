using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class ExecutionBoard
    {
        public int Id { get; set; }
        public int ExecutionPosition { get; set; }
     
        public ApplicationUser User { get; set; }
        public Institution Institution { get; set; }
    }
}
