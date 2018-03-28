using System.Collections.Generic;

namespace IMuaythai.DataAccess.Models
{
    public class SuspensionType: Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Localization { get; set; }

        public virtual ICollection<Suspension> Suspensions { get; set; }
    }

}