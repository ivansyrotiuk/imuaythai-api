using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MuaythaiSportManagementSystemApi.Models.AccountModels
{
    public class SendCodeDto
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
