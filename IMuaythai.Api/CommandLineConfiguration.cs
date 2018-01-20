using System.Linq;
using Microsoft.Extensions.Configuration;

namespace IMuaythai.Api
{
    public static class CommandLineConfiguration
    {
        private const string SetupLocal = "local";
        private const string InitLocal = "init";
        public static IConfiguration Configuration { get; set; }

        public static bool NeedSetupLocal => Configuration.AsEnumerable().Any(conf => conf.Value.Equals(SetupLocal));
        public static bool NeedInitLocal => Configuration.AsEnumerable().Any(conf => conf.Value.Equals(InitLocal));
    }
}