using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class UserDocumentsMapping
    {
        [Key]
        public int Id { get; set; }

        public virtual Document Document { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
