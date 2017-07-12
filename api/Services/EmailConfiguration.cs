using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MuaythaiSportManagementSystemApi.Services
{
    public class EmailConfiguration
    {
        public string SmtpServer { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string SmtpEmail { get; set; }
    }
}