using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class InstitutionDocumentsMapping
    {
        public int Id { get; set; }

        public Document Document { get; set; }
        public Institution Institution { get; set; }

    }
}
