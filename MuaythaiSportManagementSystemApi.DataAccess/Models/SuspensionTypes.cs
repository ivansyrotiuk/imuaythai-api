using System;
using System.Collections.Generic;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class SuspensionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Localization { get; set; }

        public virtual ICollection<Suspension> Suspensions { get; set; }
    }

}