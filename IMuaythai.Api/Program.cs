using IMuaythai.Api.Launchers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace IMuaythai.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CommandLineConfiguration.Configuration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            if (CommandLineConfiguration.NeedSetupLocal)
            {
                LauncherConfigurationManager.CreateLocalInstanseConfiguration();
                return;
            }

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://0.0.0.0:5000/")
                .Build();
        }     
    }
}
