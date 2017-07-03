using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class ContestDocumentsMapping
    {
        public int Id { get; set; }

        public Document Document { get; set; }
        public Contest Institution { get; set; }

    }
}
