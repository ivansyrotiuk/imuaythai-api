using System;
using System.IO;
using IMuaythai.Api.Launchers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;

namespace IMuaythai.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0 && args[0].Equals("local"))
            {
                LauncherConfigurationManager.CreateLocalInstanseConfiguration();
                return;    
            }

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var urls = $"http://*:{Environment.GetEnvironmentVariable("PORT") ?? "5000"}/";
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(urls)
                .Build();
        }     
    }
}
