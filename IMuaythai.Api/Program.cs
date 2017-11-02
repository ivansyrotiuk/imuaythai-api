using System;
using System.IO;
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
                CreateLocalInstanseConfiguration();
                return;    
            }

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://0.0.0.0:5000")
                .UseStartup<Startup>()
                .Build();

        private static void CreateLocalInstanseConfiguration()
        {
            const string settingsFile = "appsettings.json";
            if (!File.Exists(settingsFile))
            {
                Console.WriteLine("Configuration file is not existed.");
                Console.ReadKey();
                return;
            }

            string json = File.ReadAllText(settingsFile);
            JObject configuration = JObject.Parse(json);
            var connectionStrings = configuration["ConnectionStrings"];
            connectionStrings["DefaultConnection"] = "Server=(localdb)\\MSSQLLocalDB;Database=imuaythai_local_contest;Trusted_Connection=True;";
            json = configuration.ToString();
            File.WriteAllText(settingsFile, json);
        }
    }
}
