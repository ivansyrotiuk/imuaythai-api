using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Continent { get; set; }

        public virtual IEquatable<ApplicationUser> Users { get; set; }
        public virtual IEquatable<Institution> Institutions { get; set; }
        public virtual IEquatable<Contest> Contests { get; set; }
    }
}
