using System;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class SuspensionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Localization { get; set; }

        public virtual IEquatable<Suspension> Suspensions { get; set; }
    }

}